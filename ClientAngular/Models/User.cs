using System.Collections.Generic;

namespace ClientAngular.Models
{
    //Newtonsoft.Json can't deserialize Classes, which were nherited from Interfaces
    public class User //: IUser
    {
        public string id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string email { get; set; }
        public string title { get; set; }
        public string picture { get; set; }
    }

    public class Users //: IUsers
    {
        public List<User> data { get; set; }
        public int total { get; set; }
        public int page { get; set; }
        public int limit { get; set; }
    }
}
