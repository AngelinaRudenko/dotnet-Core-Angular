using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using ClientAngular.Models;

namespace ClientAngular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportTxtController : ControllerBase
    {
        private readonly IWebHostEnvironment _appEnvironment;

        public ReportTxtController(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        //output:       firstName lastName: email
        [HttpGet]
        public async Task<FileResult> Get()
        {
            WebRequest request = WebRequest.Create("https://localhost:44300/api/users?limit=100");
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

            string path = Path.Combine(_appEnvironment.ContentRootPath, "wwwroot", "report.txt");

            //https://metanit.com/sharp/tutorial/5.4.php
            using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
            {
                foreach (User user in users.data)
                {
                    // sting to bytes
                    str = $"{user.firstName} {user.lastName}: {user.email}\n";
                    byte[] array = System.Text.Encoding.Default.GetBytes(str);
                    await fstream.WriteAsync(array, 0, array.Length);
                }
            }

            //Send FileSream
            //https://metanit.com/sharp/aspnet5/5.7.php
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            string file_type = "text/plain";
            string file_name = "report.txt";
            return File(fs, file_type, file_name);
        }
    }
}
