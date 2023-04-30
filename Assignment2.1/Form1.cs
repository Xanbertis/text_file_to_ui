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
}
