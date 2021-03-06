﻿using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace ParentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        ///GET .../users
        [HttpGet]
        public async Task<string> GetAsync(int limit = 20, int page = 0)
        {
            WebRequest request = WebRequest.Create($"https://dummyapi.io/data/api/user?limit={limit}&page={page}");
            request.Method = "GET";
            request.Headers["app-id"] = "603f7a4dbe13b16adaa19d17";

            WebResponse response = await request.GetResponseAsync();
            string str = "";
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    str = reader.ReadToEnd();
                }
            }
            response.Close();
            return str;
        }
    }
}
