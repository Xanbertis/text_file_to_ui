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

                UserInfoForm form = parser.StoreUserInfos();

                if(form.Role == "student")
                {
                    label6.Text = "Favorite course";
                }
                else
                {
                    label6.Text = "Department";
                }

                textBox1.Text = $"{form.Name} {form.Surname}";
                textBox2.Text = form.Year_of_birth;
                textBox3.Text = form.City_of_origin;
                textBox4.Text = form.Faculty;
                textBox5.Text = form.Role;
                textBox6.Text = form.RoleSpecAttr;

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void textBox5_TextChanged(object sender, EventArgs e) { }
        private void textBox6_TextChanged(object sender, EventArgs e) { }
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
