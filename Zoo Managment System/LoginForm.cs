using MySql.Data.MySqlClient;
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
                //Showbox(CalculateMD5Hash(passTextBox.Text));
                string connetionString = null;
                MySqlConnection cnn;
                connetionString = "server=96.125.160.33;database=uptodeal_ZooDatabase;uid=uptodeal_ZooApp;pwd=ZooAppPass@;";
                cnn = new MySqlConnection(connetionString);

                try
                {
                    cnn.Open();
                    MessageBox.Show("Connection opend");

                    MySqlCommand command;
                    MySqlDataReader mdr;
                    string selectQuery = "SELECT * FROM uptodeal_ZooDatabase.Users WHERE username='ramy'";
                    command = new MySqlCommand(selectQuery, cnn);
                    mdr = command.ExecuteReader();
                    if (mdr.Read())
                    {

                        MessageBox.Show(mdr.GetString("username") + mdr.GetString("password"));

                    }




                    cnn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    
                }






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

        private void testButton_Click(object sender, EventArgs e)
        {
            administratorForm adminForm = new administratorForm();
            adminForm.Show();
        }
    }
}