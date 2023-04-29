using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Assignment2._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private UserDisplayer userDisplayer;

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set the file dialog properties
            openFileDialog2.Filter = "User Form Infos (*.ufi)|*.ufi|Text files (*.txt)|*.txt";
            openFileDialog2.Title = "Select a User Infos file";

            // Show the dialog and process the result
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                // The user selected a file, do something with it
                string selectedFilePath = openFileDialog2.FileName;


                UserFileReader reader = new UserFileReader();
                reader.UserFileName = selectedFilePath;
                string fileContent = reader.readData();

                // Print the file content to the terminal
                Console.WriteLine(fileContent);

                UserParser parser = new UserParser(fileContent);

                userDisplayer = new UserDisplayer(parser.Normalized_data);
                parser.CreateUser(userDisplayer);
                parser.StoreUserInfos();




    }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class UserFileReader
    {
        public string UserFileName { get; set; }

        public string readData()
        {
            string content = "";

            try
            {
                content = File.ReadAllText(UserFileName);
            }
            catch (IOException e)
            {
                // Handle the exception
                MessageBox.Show("An error occurred while reading the file: " + e.Message);
            }

            return content;
        }
    }

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

        public void StoreUserInfos()
        {
            User_Displayer.createForm();
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

    class User
    {
        public List<Dictionary<string, string>> normalized_data;

        public User(List<Dictionary<string, string>> normalized_data)
        {
            this.normalized_data = normalized_data;
        }
    }

    class UserDisplayer
    {
        public List<Dictionary<string, string>> Input_data;
        public User User_to_display;

        public UserDisplayer(List<Dictionary<string, string>> normalized_data)
        {
            this.Input_data = normalized_data;
        }

        public void createForm()
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

            form.PrintForm();
        }
    }

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

        public void PrintForm()
        {
            
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
