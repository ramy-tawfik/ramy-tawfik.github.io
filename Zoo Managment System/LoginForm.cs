﻿using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Zoo_Managment_System
{
    public partial class Login : Form
    {
        private static int attemptCounter ;

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
            return sb.ToString();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string userName = userTextBox.Text;
            string pass = CalculateMD5Hash(passTextBox.Text);
            string message = null;

            if (attemptCounter > 0)
            {
                if (userTextBox.Text.Length > 0 && passTextBox.Text.Length > 0)
                {
                                    

                    string connetionString = null;
                    MySqlConnection cnn;
                    connetionString = "server=96.125.160.33;database=uptodeal_ZooDatabase;uid=uptodeal_ZooApp;pwd=ZooAppPass@;";
                    cnn = new MySqlConnection(connetionString);

                    try
                    {
                        MessageBox.Show("Connection opend");
                        MySqlCommand command;
                        MySqlDataReader reader;
                        string selectQuery = "SELECT * FROM uptodeal_ZooDatabase.Users Where username =@userName AND password =@pass";
                        command = new MySqlCommand(selectQuery, cnn);

                        command.Parameters.Add("@userName", MySqlDbType.Text);
                        command.Parameters["@userName"].Value = userName;

                        command.Parameters.Add("@pass", MySqlDbType.Text);
                        command.Parameters["@pass"].Value = pass;

                        cnn.Open();
                        reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            User user = new User();
                            user.FirstName = reader.GetString("First_Name");
                            user.LasttName = reader.GetString("Last_Name");
                            if (reader.GetString("Role").Equals("admin"))
                            {
                                user.Role = userRole.Admin;
                            }
                            else
                            {
                                user.Role = userRole.ZooKeeper;
                            }

                            message += "First Name : " + user.FirstName + "\t" +
                                "Last Name : " + user.LasttName + "\t" +
                                "Role : " + user.Role + "\n";
                            MessageBox.Show(message);

                            openAdminForm(user);
                        }
                        else
                        {
                            MessageBox.Show("Wrong Username And/Or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            attemptCounter--;
                            RemainAttemptLabel.Text = "Attempts Left : " + attemptCounter.ToString();
                        }

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
                    MessageBox.Show("Username and Password can not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            }
            else {
                MessageBox.Show("No More Attempts", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        public static void Showbox(string input)
        {
            //test md5 function
            MessageBox.Show(input, "Caption", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void openAdminForm(User user)
        {
            administratorForm adminForm = new administratorForm(user);
            this.Hide();
            //adminForm.Show();
            adminForm.ShowDialog();
            this.Close();

        }
        private void testButton_Click(object sender, EventArgs e)
        {
            User user = new User();
            administratorForm adminForm = new administratorForm(user);
            this.Hide();
            //adminForm.Show();
            adminForm.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = new User();
            ZooKeeperForm zooKeeperForm = new ZooKeeperForm(user);
            this.Hide();
            zooKeeperForm.ShowDialog();
            this.Close();
        }
    }
}