using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ParentApi.Models;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace ParentApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        public List<User> users { get; set; }
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        ///GET .../users
        [HttpGet]
        public async Task<Users> GetAsync()
        {
            WebRequest request = WebRequest.Create("https://dummyapi.io/data/api/user");
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

            //JSON deserialization
            Users myDeserializedClass = JsonConvert.DeserializeObject<Users>(str);

            return myDeserializedClass;
        }
    }
}
