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
}
