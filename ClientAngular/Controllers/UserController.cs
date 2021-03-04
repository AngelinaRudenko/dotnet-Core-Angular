using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClientAngular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {        
        [HttpGet]
        public async Task<Users> Get(int limit = 20, int page = 0)
        {
            WebRequest request = WebRequest.Create($"https://localhost:44300/api/users?limit={limit}&page={page}"); 
            request.Method = "GET";

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
            Users users = JsonConvert.DeserializeObject<Users>(str);

            return users;       
        }
    }
}
