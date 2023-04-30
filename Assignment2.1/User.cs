using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2._1
{
    class User
    {
        public List<Dictionary<string, string>> normalized_data;

        public User(List<Dictionary<string, string>> normalized_data)
        {
            this.normalized_data = normalized_data;
        }
    }
}
