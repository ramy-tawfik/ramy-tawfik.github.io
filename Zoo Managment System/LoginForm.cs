using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Zoo_Managment_System
{
    public partial class Login : Form
    {
        private static int attemptCounter = 0;

        public Login()
        {
            InitializeComponent();
        }

        //function to Convert the password using a message digest five (MD5) hash
        public static string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            System.Text.StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (userTextBox.Text.Length > 0 && passTextBox.Text.Length > 0)
            {
                attemptCounter++;
                Showbox(CalculateMD5Hash(passTextBox.Text));
            }
            else
            {
                MessageBox.Show("Username and Password can not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public static void Showbox(string input)
        {
            //test md5 function
            MessageBox.Show(input, "Caption", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}