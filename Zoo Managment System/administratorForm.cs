using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Windows.Forms;
using Zoo_Managment_System;

namespace Zoo_Management_System
{
    public partial class administratorForm : Form
    {
        private readonly User loggeduser;
        private bool animalLoaded = false;

        // ArrayList to save animals list retrieved from the Database
        private ArrayList animalList = new ArrayList();

        // ArrayList to save Users list retrieved from the Database
        private ArrayList userList = new ArrayList();

        public administratorForm(User user)
        {
            InitializeComponent();
            this.loggeduser = user;
            userLabel.Text = user.displayName().ToUpper();
            timeLabel.Text = DateTime.Today.ToString();
            tabcontrol.SelectedTab = userTab; // set defaults
        }

        // user tab selected
        private void taskOneBtn_Click(object sender, System.EventArgs e)
        {
            tabPanel.Height = taskOneBtn.Height;
            tabPanel.Top = taskOneBtn.Top;
            tabcontrol.SelectedTab = userTab;

            tabPanel2.Height = taskOneBtn.Height;
            tabPanel2.Top = taskOneBtn.Top;
        }

        //  animals tab selected
        private void taskTwoBtn_Click(object sender, System.EventArgs e)
        {
            tabPanel.Height = taskTwoBtn.Height;
            tabPanel.Top = taskTwoBtn.Top;
            tabcontrol.SelectedTab = animalTab;

            tabPanel2.Height = taskTwoBtn.Height;
            tabPanel2.Top = taskTwoBtn.Top;

            // use connectAnimal only once
            if (!animalLoaded)
            {
                connectAnimal();
            }
        }

        private void taskThreeBtn_Click(object sender, System.EventArgs e)
        {
            tabPanel.Height = taskThreeBtn.Height;
            tabPanel.Top = taskThreeBtn.Top;
            tabcontrol.SelectedTab = thirdTab;

            tabPanel2.Height = taskThreeBtn.Height;
            tabPanel2.Top = taskThreeBtn.Top;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = DateTime.Now.ToString();
        }

        // Load user from database to ArrayList
        private void connectUsers()
        {
            userList.Clear();
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=96.125.160.33;database=uptodeal_ZooDatabase;uid=uptodeal_ZooApp;pwd=ZooAppPass@;";
            cnn = new MySqlConnection(connetionString);

            try
            {
                MySqlCommand command;
                MySqlDataReader mdr;
                string selectQuery = "SELECT * FROM uptodeal_ZooDatabase.Users";
                command = new MySqlCommand(selectQuery, cnn);
                cnn.Open();
                mdr = command.ExecuteReader();

                while (mdr.Read())
                {
                    User user = new User();
                    user.userID = mdr.GetInt32("ID");
                    user.FirstName = mdr.GetString("First_Name");
                    user.LastName = mdr.GetString("Last_Name");
                    user.Username = mdr.GetString("Username");
                    if (mdr.GetString("Role").Equals("Admin"))
                        user.Role = userRole.Admin;
                    else
                    {
                        user.Role = userRole.ZooKeeper;
                    }
                    userList.Add(user);
                }

                cnn.Close();
                populateUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void connectAnimal()
        {
            animalList = AnimalHelper.GetAnimalList();

            int ampCount = 0, birdCount = 0, mamalCount = 0, reptileCount = 0;
            int NormalCount = 0, ExtinctCount = 0, VulnerableCount = 0, NearThreatCount = 0, EndangeredCount = 0, LeastConcernCount = 0,
                 CriticallyCount = 0;
            //count animals by class and by status
            foreach (Animal item in animalList)
            {
                switch (item.AnimalClass)
                {
                    case animalClass.Amphibian:
                        ampCount++;
                        break;

                    case animalClass.Bird:
                        birdCount++;
                        break;

                    case animalClass.Mammal:
                        mamalCount++;
                        break;

                    case animalClass.Reptile:
                        reptileCount++;
                        break;

                    default:
                        break;
                }
                // count animal by status
                switch (item.Status)
                {
                    case animalStatus.Normal:
                        NormalCount++;
                        break;

                    case animalStatus.ExtinctInTheWild:
                        ExtinctCount++;
                        break;

                    case animalStatus.Vulnerable:
                        VulnerableCount++;
                        break;

                    case animalStatus.NearThreatened:
                        NearThreatCount++;
                        break;

                    case animalStatus.Endangered:
                        EndangeredCount++;
                        break;

                    case animalStatus.LeastConcern:
                        LeastConcernCount++;
                        break;

                    case animalStatus.CriticallyEndangered:
                        CriticallyCount++;
                        break;

                    default:
                        break;
                }
            }
            // write count values
            totalLabel.Text = animalList.Count.ToString();
            amplabel.Text = ampCount.ToString();
            birdLabel.Text = birdCount.ToString();
            mamalLabel.Text = mamalCount.ToString();
            reptileLabel.Text = reptileCount.ToString();
            normlabel.Text = NormalCount.ToString();
            extlabel.Text = ExtinctCount.ToString();
            vullabel.Text = VulnerableCount.ToString();
            nearlabel.Text = NearThreatCount.ToString();
            endlabel.Text = EndangeredCount.ToString();
            leastlabel.Text = LeastConcernCount.ToString();
            criticlabel.Text = CriticallyCount.ToString();

            animalLoaded = true;
        }

        private void administratorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }

        private void administratorForm_Load(object sender, EventArgs e)
        {
            connectUsers();
        }

        private void tabcontrol_Selected(object sender, TabControlEventArgs e)
        {
        }

        private void populateUsers()
        {
            usersDataGridView.Rows.Clear();
            int admins = 0, zooKeepers = 0;
            foreach (User item in userList)
            {
                if (item.Role == userRole.Admin)
                {
                    admins += 1;
                }
                else if (item.Role == userRole.ZooKeeper)
                {
                    zooKeepers += 1;
                }
                usersDataGridView.Rows.Add(item.userID, item.FirstName, item.LastName, item.Username, item.Role);

                adminNoLb.Text = admins.ToString();
                zookeeperNo.Text = zooKeepers.ToString();
                totalLable.Text = (admins + zooKeepers).ToString();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            this.Opacity = .55;
            addUserForm addUserForm = new addUserForm();

            addUserForm.ShowDialog();

            if (addUserForm.validUser)
            {
                connectUsers();
            }
            this.Opacity = 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void usersDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Case of update cell clicked
            if (e.ColumnIndex.Equals(5) && e.RowIndex >= 0)
            {
                DataGridViewRow row = usersDataGridView.Rows[e.RowIndex];
                string value1 = row.Cells[0].Value.ToString();
                User updateUser = new User();
                foreach (User item in userList)
                {
                    if (item.userID == Int16.Parse(value1))
                    {
                        updateUser = item;
                        break;
                    }
                }

                updateUserForm updateUserform = new updateUserForm(updateUser);
                updateUserform.ShowDialog();
                if (updateUserform.userUpdated)
                {
                    connectUsers();
                }
            }

            //// case if Delete cell clicked
            if (e.ColumnIndex.Equals(6) && e.RowIndex >= 0)
            {
                DataGridViewRow row = usersDataGridView.Rows[e.RowIndex];
                int selectedID = (int)row.Cells[0].Value;
                User updateUser = new User();
                DialogResult result = MessageBox.Show("Selected User Will be Deleted,  Are you sure?   ", "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    string connetionString = null;
                    MySqlConnection cnn;
                    connetionString = "server=96.125.160.33;database=uptodeal_ZooDatabase;uid=uptodeal_ZooApp;pwd=ZooAppPass@;";
                    cnn = new MySqlConnection(connetionString);

                    try
                    {
                        MySqlCommand command;
                        MySqlDataReader mdr;
                        string selectQuery = "DELETE FROM uptodeal_ZooDatabase.Users WHERE ID = @ID";
                        command = new MySqlCommand(selectQuery, cnn);
                        command.Parameters.Add("@ID", MySqlDbType.Int16);
                        command.Parameters["@ID"].Value = selectedID;
                        cnn.Open();
                        mdr = command.ExecuteReader();
                        connectUsers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}