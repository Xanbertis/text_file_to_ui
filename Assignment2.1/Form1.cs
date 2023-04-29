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
            }
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

        public void CreateUser(string user_data)
        {
            // Split the user data into separate fields
            string[] fields = user_data.Split(';');

            // Create a new User object with the fields
            User user = new User(Normalized_data);
        }

        public void StoreUserInfos()
        {
            // Create a new instance of UserDisplayer
            UserDisplayer userDisplayer = new UserDisplayer();
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
        public void DisplayUserInfo(string[] user_data)
        {
            throw new NotImplementedException();
        }
    }

}
