using System.Collections.Generic;
using Newtonsoft.Json;

namespace ClientAngular.Models
{
    public interface IUser
    {
        string lastName { get; set; }
        string firstName { get; set; }
        string email { get; set; }
    }

    public interface IUsers
    {
        List<IUser> data { get; set; }
        int total { get; set; }
        int page { get; set; }
        int limit { get; set; }
    }
}