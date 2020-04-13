using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Zoo_Managment_System;

namespace Zoo_Management_System
{
    public partial class ZooKeeperForm : Form
    {
        private ArrayList animalList = new ArrayList();
        private ArrayList addedAnimalList = new ArrayList();
        private string connetionString = null;
        private User loggedUser = new User();
        private MySqlConnection cnn;
        private MySqlDataAdapter dataSelect;
        private DataSet dataset;

        public ZooKeeperForm(User user)
        {
            InitializeComponent();
            animalList = AnimalHelper.GetAnimalList();
            tabControl1.SelectedIndex = 1;
            loggedUser = user;
        }

        private void ZooKeeperForm_Load(object sender, EventArgs e)
        {
            userLabel.Text = loggedUser.FirstName + " " + loggedUser.LastName;
            timeLabel.Text = DateTime.Now.ToString();
            // Fill animal class comboBox with animalClas enum Values
            foreach (var item in Enum.GetValues(typeof(AnimalClass)))
            {
                ClassComboBox.Items.Add(item.ToString());
                classAddCB.Items.Add(item.ToString());
            }

            foreach (Animal item in animalList)
            {
                // set animal species
                if (!speciesComboBox.Items.Contains(item.Species))
                {
                    speciesComboBox.Items.Add(item.Species);
                }
            }
        }

        // load animal database into animalArraylist

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            reset();
        }

        private void reset()
        {
            ClassComboBox.SelectedIndex = 0;
            statusComboBox.SelectedIndex = 0;
            speciesComboBox.SelectedIndex = 0;
        }

        private void resetAddForm()
        {
            classAddCB.SelectedItem = "";
            statusAddCB.SelectedItem = "";
            speciesAddCB.SelectedItem = "";
            speciesAddCB.Enabled = false;
            genderAddCB.SelectedItem = "";
            lastFeedDTPicker.Value = DateTime.Now;
            addedAnimalList.Clear();
        }

        // fill dataGridView with data from the array list
        private void PopulateData()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            string classGroup, statusGroup, speciesGroup;
            classGroup = ClassComboBox.SelectedItem.ToString();
            statusGroup = statusComboBox.SelectedItem.ToString();
            speciesGroup = speciesComboBox.SelectedItem.ToString();

            foreach (Animal item in animalList)
            {
                // set animal status
                // fill with all animals info
                if ((item.AnimalClass.ToString().Equals(classGroup) || classGroup.Equals("All"))
                   && (item.Status.ToString().Equals(Regex.Replace(statusGroup, @"\s", "")) || statusGroup.Equals("All Statuses"))
                   && (item.Species.ToString().Equals(speciesGroup) || speciesGroup.Equals("All"))
                   )
                {
                    dataGridView1.Rows.Add(item.AnimalID, item.AnimalClass, item.AnimalName, item.Species, item.Gender, item.LastFeed, item.Status);
                }
            }
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            PopulateData();
        }

        private void ZooKeeperForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void OpenConnection()
        {
            connetionString = "server=96.125.160.33;database=uptodeal_ZooDatabase;uid=uptodeal_ZooApp;pwd=ZooAppPass@;";
            cnn = new MySqlConnection(connetionString);
            try
            {
                cnn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        // close database connection
        private void CloseConnection()
        {
            if (cnn.State == System.Data.ConnectionState.Open)
            {
                cnn.Close();
            }
        }

        // search for animal info by class
        private void classTB_TextChanged(object sender, EventArgs e)
        {
            string parmSt = classTB.Text + "%";
            SearchAnimal("Class", parmSt);
        }

        // search for animal info by name
        private void nameTB_TextChanged(object sender, EventArgs e)
        {
            string parmSt = nameTB.Text + "%";
            SearchAnimal("Name", parmSt);
        }

        // search for animal info by status
        private void StatusTB_TextChanged(object sender, EventArgs e)
        {
            string parmSt = StatusTB.Text + "%";
            SearchAnimal("Status", parmSt);
        }

        // search for animal info by Species
        private void SpeciesTB_TextChanged(object sender, EventArgs e)
        {
            string parmSt = SpeciesTB.Text + "%";
            SearchAnimal("Species", parmSt);
        }

        private void SearchAnimal(string searchParmValue, string parmString)
        {
            OpenConnection();
            dataSelect = new MySqlDataAdapter();
            string selectString = "";
            switch (searchParmValue)
            {
                case "Class":
                    selectString = "SELECT * FROM uptodeal_ZooDatabase.Animal WHERE Class LIKE @parm";
                    break;

                case "Name":
                    selectString = "SELECT * FROM uptodeal_ZooDatabase.Animal WHERE Name LIKE @parm";
                    break;

                case "Status":
                    selectString = "SELECT * FROM uptodeal_ZooDatabase.Animal WHERE Status LIKE @parm";
                    break;

                case "Species":
                    selectString = "SELECT * FROM uptodeal_ZooDatabase.Animal WHERE Species LIKE @parm";
                    break;

                default:
                    break;
            }

            // selectString contains parameters
            MySqlCommand command = new MySqlCommand(selectString, cnn);
            command.Parameters.Add("@parm", MySqlDbType.Text);
            command.Parameters["@parm"].Value = parmString;

            dataSelect.SelectCommand = command;
            dataset = new DataSet();
            dataSelect.Fill(dataset);
            dataGridView2.DataSource = dataset.Tables[0];

            CloseConnection();
        }

        //Switch the view to search tab
        private void SearchBTN_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        // switch view to home tab
        private void HomeBTN_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        // clear the text box text on click
        private void ClassTB_MouseClick(object sender, MouseEventArgs e)
        {
            classTB.Text = "";
            SpeciesTB.Text = "Species";
            nameTB.Text = "Name";
            StatusTB.Text = "Status";
        }

        // clear the text box text on click
        private void NameTB_MouseClick(object sender, MouseEventArgs e)
        {
            classTB.Text = "Class";
            SpeciesTB.Text = "Species";
            nameTB.Clear();
            StatusTB.Text = "Status";
        }

        // clear the text box text on click
        private void SpeciesTB_MouseClick(object sender, MouseEventArgs e)
        {
            classTB.Text = "Class";
            SpeciesTB.Clear();
            nameTB.Text = "Name";
            StatusTB.Text = "Status";
            string parmSt = "%";
            SearchAnimal("Class", parmSt);
        }

        // clear the text box text on click
        private void SpeciesTB_MouseClick_1(object sender, MouseEventArgs e)
        {
            classTB.Text = "Class";
            SpeciesTB.Clear();
            nameTB.Text = "Name";
            StatusTB.Text = "Status";
            string parmSt = "%";
            SearchAnimal("Class", parmSt);
        }

        private void searchPanel_Paint(object sender, PaintEventArgs e)
        {
            classTB.Text = "Class";
            SpeciesTB.Text = "Species";
            nameTB.Text = "Name";
            StatusTB.Text = "Status";
            string parmSt = "%";
            SearchAnimal("Class", parmSt);
        }

        private void StatusTB_MouseClick(object sender, MouseEventArgs e)
        {
            classTB.Text = "Class";
            SpeciesTB.Text = "Species";
            nameTB.Text = "Name";
            StatusTB.Clear();
            string parmSt = "%";
            SearchAnimal("Class", parmSt);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(7) && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string value1 = row.Cells[0].Value.ToString();
                Animal updatedAnimal = new Animal();
                foreach (Animal item in animalList)
                {
                    if (item.AnimalID == Int16.Parse(value1))
                    {
                        updatedAnimal = item;
                        break;
                    }
                }
                updateAnimalForm updateAnimalForm = new updateAnimalForm(animalList, updatedAnimal);
                updateAnimalForm.ShowDialog();
                if (updateAnimalForm.animalUpdated)
                {
                    animalList = AnimalHelper.GetAnimalList();
                    PopulateData();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void ZookeeperTimer_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = DateTime.Now.ToString();
        }

        private void Label13_Click(object sender, EventArgs e)
        {
            lastFeedDTPicker.Value = DateTime.Now;
        }

        private int tempID = 0;

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (ValidateAddAnimal())
            {
                Animal animal = new Animal();
                animal.AnimalID = tempID;
                tempID++;
                animal.AnimalName = animalNameAddTB.Text;
                animal.AnimalClass = (AnimalClass)Enum.Parse(typeof(AnimalClass), classAddCB.SelectedItem.ToString());
                animal.Status = (AnimalStatus)Enum.Parse(typeof(AnimalStatus), Regex.Replace(statusAddCB.SelectedItem.ToString(), @"\s", ""));
                if (speciesAddCB.SelectedItem.Equals("New"))
                {
                    animal.Species = newSpeciesTB.Text;
                }
                else
                {
                    animal.Species = speciesAddCB.SelectedItem.ToString();
                }
                animal.LastFeed = lastFeedDTPicker.Value;
                animal.Gender = genderAddCB.SelectedItem.ToString();
                addedAnimalList.Add(animal);
                addAnimalGridView.Rows.Add(animal.AnimalID, animal.AnimalClass, animal.AnimalName, animal.Species, animal.Gender, animal.LastFeed, animal.Status);
                animalNameAddTB.Text = "";
            }
            else
            {
                MessageBox.Show("Please Fill All Required Data", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            resetAddForm();
        }

        // Now Label clicked
        private void nowLabel_Click(object sender, EventArgs e)
        {
            lastFeedDTPicker.Value = DateTime.Now;
        }

        // Animal Class selected from the combo box
        private void classAddCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (classAddCB.SelectedIndex > -1)
            {
                speciesAddCB.Enabled = true;
                speciesAddCB.Items.Clear();
                speciesAddCB.Items.Add("New");

                // fill Species combo Box with species belong to the selected class
                foreach (Animal item in animalList)
                {
                    // set animal species
                    if (!speciesAddCB.Items.Contains(item.Species))
                    {
                        if (item.AnimalClass.ToString().Equals(classAddCB.SelectedItem.ToString()))
                        {
                            speciesAddCB.Items.Add(item.Species);
                        }
                    }
                }
            }
        }

        private void speciesAddCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (speciesAddCB.SelectedItem.Equals("New"))
            {
                newSpeciesTB.Enabled = true;
            }
            else
            {
                newSpeciesTB.Enabled = false;
            }
        }

        private void NewSpeciesLabel_Click(object sender, EventArgs e)
        {
            newSpeciesTB.Enabled = true;
            speciesAddCB.SelectedItem = "New";
        }

        // Check if Valid user info is entered
        private bool ValidateAddAnimal()
        {
            if ((animalNameAddTB.Text.Length < 1) || (statusAddCB.SelectedIndex == -1) ||
                (classAddCB.SelectedIndex == -1) || (speciesAddCB.SelectedIndex == -1)
                || (genderAddCB.SelectedIndex == -1)
                )
            {
                return false;
            }
            if (speciesAddCB.SelectedItem.Equals("New") & newSpeciesTB.Text == "")
            {
                return false;
            }

            return true;
        }

        [Obsolete]
        // Add Animals to database and update
        private void UpdateBTN_Click(object sender, EventArgs e)
        {
            // Check if Valid user info is entered
            if (addedAnimalList.Count != 0)
            {
                string connetionString = null;
                MySqlConnection cnn;
                connetionString = "server=96.125.160.33;database=uptodeal_ZooDatabase;uid=uptodeal_ZooApp;pwd=ZooAppPass@;";
                cnn = new MySqlConnection(connetionString);
                try
                {
                    MySqlCommand command;
                    MySqlDataReader mdr;
                    foreach (Animal animal in addedAnimalList)
                    {
                        string selectQuery = "INSERT INTO uptodeal_ZooDatabase.Animal (Class,Species,Status,Name,Gender,LastFeed) VALUES (@class, @species,@status,@name, @gender,@LastFeed)";

                        command = new MySqlCommand(selectQuery, cnn);
                        command.Parameters.Add("@class", MySqlDbType.Text);
                        command.Parameters["@class"].Value = animal.AnimalClass.ToString();

                        command.Parameters.Add("@species", MySqlDbType.Text);
                        command.Parameters["@species"].Value = animal.Species.ToString();

                        command.Parameters.Add("@status", MySqlDbType.Text);
                        command.Parameters["@status"].Value = animal.Status.ToString();

                        command.Parameters.Add("@name", MySqlDbType.Text);
                        command.Parameters["@name"].Value = animal.AnimalName.ToString();

                        command.Parameters.Add("@gender", MySqlDbType.Text);
                        command.Parameters["@gender"].Value = animal.Gender.ToString();

                        command.Parameters.Add("@LastFeed", MySqlDbType.Datetime);
                        command.Parameters["@LastFeed"].Value = animal.LastFeed;

                        cnn.Open();
                        mdr = command.ExecuteReader();
                        cnn.Close();
                    }
                    addAnimalGridView.Rows.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                MessageBox.Show("Added Successfully\t\t");
                // update the initial array list that used for populate animal data in the main view
                // to show the newly added data
                animalList = AnimalHelper.GetAnimalList();
                addedAnimalList.Clear();
            }
            // if no animals added to Queue
            else if (ValidateAddAnimal())
            {
                MessageBox.Show("Please Add Animal First\t\t", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //If no Animal added to the list before update
                MessageBox.Show("Nothing to ADD\t\t", "Error");
            }
        }

        private void AddAnimalBTN_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void AddAnimalGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Delete animal cell clicked
            if (e.ColumnIndex.Equals(7) && e.RowIndex >= 0)
            {
                int index = -1;
                DialogResult result = MessageBox.Show("Selected animal will be DELETED from the queue,  Are you sure?   ", "Delete ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                // user selected to delete animal from the queue
                if (result == DialogResult.Yes)
                {
                    foreach (Animal item in addedAnimalList)
                    {
                        if (item.AnimalID == Convert.ToInt32(addAnimalGridView.Rows[e.RowIndex].Cells[0].Value))
                        {
                            index = addedAnimalList.IndexOf(item);
                            break;
                        }
                    }
                    if ((index >= 0) & (index <= addedAnimalList.Count - 1))
                    {
                        addedAnimalList.RemoveAt(index);
                        addAnimalGridView.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }
    }
}