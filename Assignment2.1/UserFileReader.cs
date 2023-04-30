using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Assignment2._1
{
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
