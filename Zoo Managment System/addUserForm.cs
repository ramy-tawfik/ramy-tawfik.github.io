using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Zoo_Management_System
{
    public partial class addUserForm : Form
    {
        public User addedUser = new User();
        public bool validUser = false;

        public addUserForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // When add user button clicked
        private void addUserBTN_Click(object sender, EventArgs e)
        {
            // If user name or password less than 4 characters
            if (usernameTB.Text.Length < 4 || passwordTB.Text.Length < 4)
            {
                MessageBox.Show("Username and Password less than 4 characters ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // If any of the text boxes is empty
            else if (fNameTB.Text.Length < 1 || lNameTB.Text.Length < 1 || roleCB.SelectedIndex < 0)
            {
                MessageBox.Show("Please Fill All Required Data", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                addedUser.FirstName = fNameTB.Text;
                addedUser.LastName = lNameTB.Text;
                if (roleCB.SelectedItem.ToString().Equals("Admin"))
                {
                    addedUser.Role = UserRole.Admin;
                }
                else if (roleCB.SelectedItem.Equals("ZooKeeper"))
                {
                    addedUser.Role = UserRole.ZooKeeper;
                }

                string connetionString = null;
                MySqlConnection cnn;
                connetionString = "server=96.125.160.33;database=uptodeal_ZooDatabase;uid=uptodeal_ZooApp;pwd=ZooAppPass@;";
                cnn = new MySqlConnection(connetionString);

                try
                {
                    MySqlCommand command;
                    MySqlDataReader mdr;
                    string selectQuery = "INSERT INTO uptodeal_ZooDatabase.Users ( First_Name,Last_name,Role,username,password) VALUES (@Fname, @Lname,@Role,@username, @Password)";

                    command = new MySqlCommand(selectQuery, cnn);
                    command.Parameters.Add("@Fname", MySqlDbType.Text);
                    command.Parameters["@Fname"].Value = fNameTB.Text;

                    command.Parameters.Add("@Lname", MySqlDbType.Text);
                    command.Parameters["@Lname"].Value = lNameTB.Text;

                    command.Parameters.Add("@Role", MySqlDbType.Text);
                    command.Parameters["@Role"].Value = roleCB.SelectedItem.ToString();

                    command.Parameters.Add("@username", MySqlDbType.Text);
                    command.Parameters["@username"].Value = usernameTB.Text;

                    command.Parameters.Add("@password", MySqlDbType.Text);
                    command.Parameters["@password"].Value = Login.CalculateMD5Hash(passwordTB.Text);

                    cnn.Open();
                    mdr = command.ExecuteReader();

                    cnn.Close();

                    //MessageBox.Show(userList.Count.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                validUser = true;
                this.Close();
            }
        }

        private void fNameTB_TextChanged(object sender, EventArgs e)
        {
            usernameTB.Text = fNameTB.Text + "." + lNameTB.Text;
        }

        private void lNameTB_TextChanged(object sender, EventArgs e)
        {
            usernameTB.Text = fNameTB.Text + "." + lNameTB.Text;
        }
    }
}