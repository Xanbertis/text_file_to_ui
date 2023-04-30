using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2._1
{
    class UserParser
    {
        public string Raw_file_data;
        public List<Dictionary<string, string>> Normalized_data { get; set; }

        public UserDisplayer User_Displayer;


        public UserParser(string raw_data)
        {
            Raw_file_data = raw_data;
            Normalized_data = new List<Dictionary<string, string>>();

            // Split the raw data into lines
            string[] lines = raw_data.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            // Iterate over the lines and split each line into key-value pairs
            foreach (string line in lines)
            {
                // Split the line into key-value pairs
                string[] parts = line.Split('=');

                // Create a new dictionary to store the key-value pair
                Dictionary<string, string> dict = new Dictionary<string, string>();

                // Add the key-value pair to the dictionary
                dict.Add(parts[0].Trim(), parts[1].Trim());

                // Add the dictionary to the Normalized_data list
                Normalized_data.Add(dict);
            }
        }

        public void CreateUser(UserDisplayer userDisplayer)
        {
            this.User_Displayer = userDisplayer;

            // Create a new User object with the fields
            User user = new User(Normalized_data);
        }

        public UserInfoForm StoreUserInfos()
        {
            return User_Displayer.createForm();
        }

        public void PrintNormalizedData()
        {
            foreach (var dict in Normalized_data)
            {
                foreach (var kvp in dict)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                }
                Console.WriteLine();
            }
        }
    }
}
