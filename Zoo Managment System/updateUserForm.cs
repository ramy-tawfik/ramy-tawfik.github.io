using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Zoo_Management_System
{
    public partial class updateUserForm : Form
    {
        private int userID = 0;
        public bool userUpdated = false;

        public updateUserForm(User user)
        {
            InitializeComponent();
            userID = user.userID;
            foreach (var item in Enum.GetValues(typeof(userRole)))
            {
                roleCB.Items.Add(item.ToString());
            }

            populateFields(user);
        }

        private void populateFields(User user)
        {
            fNameTB.Text = user.FirstName;
            lNameTB.Text = user.LastName;
            roleCB.SelectedItem = user.Role.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (fNameTB.Text.Length < 1 || lNameTB.Text.Length < 1 || roleCB.SelectedIndex < 0)
            {
                MessageBox.Show("Please Fill All Required Data", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                string connetionString = null;
                MySqlConnection cnn;
                connetionString = "server=96.125.160.33;database=uptodeal_ZooDatabase;uid=uptodeal_ZooApp;pwd=ZooAppPass@;";
                cnn = new MySqlConnection(connetionString);

                try
                {
                    MySqlCommand command;
                    MySqlDataReader mdr;
                    string selectQuery = "UPDATE uptodeal_ZooDatabase.Users SET First_Name =@Fname, Last_name=@Lname,Role=@Role WHERE ID =@ID ";

                    command = new MySqlCommand(selectQuery, cnn);
                    command.Parameters.Add("@Fname", MySqlDbType.Text);
                    command.Parameters["@Fname"].Value = fNameTB.Text;

                    command.Parameters.Add("@Lname", MySqlDbType.Text);
                    command.Parameters["@Lname"].Value = lNameTB.Text;

                    command.Parameters.Add("@Role", MySqlDbType.Text);
                    command.Parameters["@Role"].Value = roleCB.SelectedItem.ToString(); ;

                    command.Parameters.Add("@ID", MySqlDbType.Int16);
                    command.Parameters["@ID"].Value = userID;
                    cnn.Open();
                    mdr = command.ExecuteReader();

                    cnn.Close();
                    userUpdated = true;
                    //MessageBox.Show(userList.Count.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                this.Close();
            }
        }
    }
}