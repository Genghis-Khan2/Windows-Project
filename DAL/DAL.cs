using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using BE;

namespace DAL
{
    public class DAL
    {
        readonly string user_path = @".\Users";

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        List<User> GetUserList()
        {
            using (StreamReader sr = new StreamReader(user_path))
            {
                if (sr.Peek() != -1) // If the file is not empty
                {
                    List<User> user_list = (List<User>)JsonSerializer.Deserialize(sr.ReadToEnd(), typeof(List<User>));
                    return user_list;
                }
            }

            return new List<User>();
        }


        void AddUser(User user)
        {
            string json_string = JsonSerializer.Serialize(user, typeof(User), options);

            using (StreamWriter sw = new StreamWriter(user_path))
            {
                sw.
            }
        }
    }
}
