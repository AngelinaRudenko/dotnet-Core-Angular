using System.Collections.Generic;

namespace ParentApi.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    // according to https://json2csharp.com

    public class User
    {
        public string id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string email { get; set; }
        public string title { get; set; }
        public string picture { get; set; }
    }

    public class Users
    {
        public List<User> data { get; set; }
        public int total { get; set; }
        public int page { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
    }
}
