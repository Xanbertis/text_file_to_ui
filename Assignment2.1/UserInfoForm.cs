using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2._1
{
    class UserInfoForm
    {
        public string Name;
        public string Surname;
        public string Year_of_birth;
        public string City_of_origin;
        public string Faculty;
        public string Role;
        public string RoleSpecAttr;
        public string File_accessed_times;

        public void addUserInfo(string key, string value)
        {
            if (key == "Department" || key == "Favorite course")
            {
                this.RoleSpecAttr = value;
            }
            else
            {
                switch (key)
                {
                    case "Name":
                        this.Name = value;
                        break;
                    case "Surname":
                        this.Surname = value;
                        break;
                    case "Year of birth":
                        this.Year_of_birth = value;
                        break;
                    case "City of origin":
                        this.City_of_origin = value;
                        break;
                    case "Faculty":
                        this.Faculty = value;
                        break;
                    case "Role":
                        this.Role = value;
                        break;
                    case "File accessed times":
                        this.File_accessed_times = value;
                        break;
                    default:
                        // Handle unknown key
                        break;
                }
            }
        }

        public void Show()
        {
            Console.WriteLine($"Name: {this.Name}");
            Console.WriteLine($"Surname: {this.Surname}");
            Console.WriteLine($"Year of birth: {this.Year_of_birth}");
            Console.WriteLine($"City of origin: {this.City_of_origin}");
            Console.WriteLine($"Faculty: {this.Faculty}");
            Console.WriteLine($"Role: {this.Role}");
            Console.WriteLine($"Role specific attribute: {this.RoleSpecAttr}");
            Console.WriteLine($"File accessed times: {this.File_accessed_times}");
        }
    }
}
