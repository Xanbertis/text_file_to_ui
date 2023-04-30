using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2._1
{
    class UserDisplayer
    {
        public List<Dictionary<string, string>> Input_data;
        public User User_to_display;

        public UserDisplayer(List<Dictionary<string, string>> normalized_data)
        {
            this.Input_data = normalized_data;
        }

        public UserInfoForm createForm()
        {
            UserInfoForm form = new UserInfoForm();

            // Add each key-value pair to the form
            foreach (Dictionary<string, string> dict in Input_data)
            {
                foreach (KeyValuePair<string, string> kvp in dict)
                {
                    form.addUserInfo(kvp.Key, kvp.Value);
                }
            }

            return form;
        }
    }
}
