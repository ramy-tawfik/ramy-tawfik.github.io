using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Zoo_Management_System
{
    public partial class Login : Form
    {
        private static int attemptCounter; // count unsuccessful attempts

        public Login()
        {
            InitializeComponent();
            attemptCounter = 3;
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
            return sb.ToString(); //return hashed string
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string userName = userTextBox.Text;
            string pass = CalculateMD5Hash(passTextBox.Text);

            if (attemptCounter > 0)
            {
                if (userTextBox.Text.Length > 0 && passTextBox.Text.Length > 0)
                {
                    // connect to database
                    string connetionString = null;
                    MySqlConnection cnn;
                    connetionString = "server=96.125.160.33;database=uptodeal_ZooDatabase;uid=uptodeal_ZooApp;pwd=ZooAppPass@;";
                    cnn = new MySqlConnection(connetionString);

                    try
                    {
                        MySqlCommand command;
                        MySqlDataReader reader;
                        string selectQuery = "SELECT * FROM uptodeal_ZooDatabase.Users Where username =@userName AND password =@pass";
                        command = new MySqlCommand(selectQuery, cnn);
                        // used parameters for security to avoid SQL injection
                        command.Parameters.Add("@userName", MySqlDbType.Text);
                        command.Parameters["@userName"].Value = userName;

                        command.Parameters.Add("@pass", MySqlDbType.Text);
                        command.Parameters["@pass"].Value = pass;

                        cnn.Open();
                        reader = command.ExecuteReader();

                        if (reader.Read()) // if user found
                        {
                            User user = new User();
                            user.FirstName = reader.GetString("First_Name");
                            user.LastName = reader.GetString("Last_Name");
                            if (reader.GetString("Role").Equals("Admin"))
                            {
                                user.Role = userRole.Admin;
                            }
                            else
                            {
                                user.Role = userRole.ZooKeeper;
                            }

                            openUserForm(user);
                        }
                        else
                        {
                            MessageBox.Show("Wrong Username And/Or Password.   ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            attemptCounter--;
                            RemainAttemptLabel.Text = "Attempts Left : " + attemptCounter.ToString();
                        }

                        // close reader and connection
                        reader.Close();
                        cnn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Username and Password can not be empty    ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No More Attempts", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        // open Administrator Form and pass the logged in user object
        private void openUserForm(User user)
        {
            if (user.Role == userRole.Admin)
            {
                administratorForm adminForm = new administratorForm(user);
                this.Hide();
                //adminForm.Show();
                adminForm.ShowDialog();
            }
            else if (user.Role == userRole.ZooKeeper)
            {
                ZooKeeperForm zooKeeperForm = new ZooKeeperForm(user);
                this.Hide();
                //adminForm.Show();
                zooKeeperForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("User Role Not Specified   ", "Error ", MessageBoxButtons.OK);
            }

            this.Close();
        }

        /////// for testing Remove Me ///////
        private void testButton_Click(object sender, EventArgs e)
        {
            User user = new User();
            administratorForm adminForm = new administratorForm(user);
            this.Hide();
            //adminForm.Show();
            adminForm.ShowDialog();
            this.Close();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            userTextBox.Focus();
        }
    }
}