using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace Zoo_Management_System
{
    public partial class ZooKeeperForm : Form
    {
        private ArrayList animalList = new ArrayList();
        private string connetionString = null;
        private MySqlConnection cnn;
        private MySqlDataAdapter dataSelect;
        private DataSet dataset;

        public ZooKeeperForm(User user)
        {
            InitializeComponent();
            animalDatabaseConnect();
        }

        private void ZooKeeperForm_Load(object sender, EventArgs e)
        {
            // Fill animal class comboBox with animalClas enum Values
            foreach (var item in Enum.GetValues(typeof(animalClass)))
            {
                ClassComboBox.Items.Add(item.ToString());
            }

            foreach (Animal item in animalList)
            {
                // set animal status
                if (!speciesComboBox.Items.Contains(item.Species))
                {
                    speciesComboBox.Items.Add(item.Species);
                }
            }
        }

        // load animal database into animalArraylist
        private void animalDatabaseConnect()
        {
            MySqlCommand command;
            MySqlDataReader mdr;
            string selectQuery = "SELECT * FROM uptodeal_ZooDatabase.Animal";
            try
            {
                openConnection();

                command = new MySqlCommand(selectQuery, cnn);
                mdr = command.ExecuteReader();
                while (mdr.Read())
                {
                    Animal animal = new Animal();
                    // set animal class
                    switch (mdr.GetString("Class"))
                    {
                        case "Amphibian":
                            animal.AnimalClass = Zoo_Management_System.animalClass.Amphibian;
                            break;

                        case "Bird":
                            animal.AnimalClass = Zoo_Management_System.animalClass.Bird;
                            break;

                        case "Mammal":
                            animal.AnimalClass = Zoo_Management_System.animalClass.Mammal;
                            break;

                        case "Reptile":
                            animal.AnimalClass = Zoo_Management_System.animalClass.Reptile;
                            break;

                        default:
                            break;
                    }
                    // set animal status
                    switch (mdr.GetString("Status"))
                    {
                        case "Normal":
                            animal.Status = animalStatus.Normal;
                            break;

                        case "Extinct In The Wild":
                            animal.Status = animalStatus.ExtinctInTheWild;
                            break;

                        case "Vulnerable":
                            animal.Status = animalStatus.Vulnerable;
                            break;

                        case "Near Threatened":
                            animal.Status = animalStatus.NearThreatened;
                            break;

                        case "Endangered":
                            animal.Status = animalStatus.Endangered;
                            break;

                        case "Least Concern":
                            animal.Status = animalStatus.LeastConcern;
                            break;

                        case "Critically Endangered":
                            animal.Status = animalStatus.CriticallyEndangered;
                            break;

                        default:
                            break;
                    }

                    animal.Species = mdr.GetString("Species");
                    animal.AnimalName = mdr.GetString("Name");
                    animal.Gender = mdr.GetString("Gender");

                    // animal.LastFeed = mdr.GetDateTime("LastFeed");

                    animalList.Add(animal);
                }
                closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            ClassComboBox.SelectedIndex = 0;
            statusComboBox.SelectedIndex = 0;
            speciesComboBox.SelectedIndex = 0;
        }

        private void viewButton_Click(object sender, EventArgs e)
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
                if ((item.AnimalClass.ToString().Equals(classGroup) || classGroup.Equals("All"))
                   && (item.Status.ToString().Equals(statusGroup) || statusGroup.Equals("All Statuses"))
                   && (item.Species.ToString().Equals(speciesGroup) || speciesGroup.Equals("All"))
                   )
                {
                    dataGridView1.Rows.Add(item.AnimalClass, item.AnimalName, item.Species, item.Gender, item.Status);
                }
            }
        }

        private void ZooKeeperForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }

        private void openConnection()
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

        private void closeConnection()
        {
            if (cnn.State == System.Data.ConnectionState.Open)
            {
                cnn.Close();
            }
        }

        private void classTB_TextChanged(object sender, EventArgs e)
        {
            string selectString = "SELECT Class,Name,Species, Status FROM uptodeal_ZooDatabase.Animal WHERE Class LIKE @parm";
            string parmSt = classTB.Text + "%";
            searchAnimal(selectString, parmSt);
        }

        private void nameTB_TextChanged(object sender, EventArgs e)
        {
            string selectString = "SELECT Class,Name,Species,Status FROM uptodeal_ZooDatabase.Animal WHERE Name LIKE @parm";
            string parmSt = nameTB.Text + "%";
            searchAnimal(selectString, parmSt);
        }



        private void searchAnimal(string selectString, string parmString)
        {
            openConnection();
            dataSelect = new MySqlDataAdapter();
         
            MySqlCommand command = new MySqlCommand(selectString, cnn); ;
            command.Parameters.Add("@parm", MySqlDbType.Text);
            command.Parameters["@parm"].Value = parmString;
            dataSelect.SelectCommand = command;
            dataset = new DataSet();
            dataSelect.Fill(dataset);
            dataGridView2.DataSource = dataset.Tables[0];

            closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            searchPanel.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            searchPanel.Visible = false;
        }

        private void classTB_MouseClick(object sender, MouseEventArgs e)
        {
            classTB.Text = "";
            SpeciesTB.Text = "Species";
            nameTB.Text = "Name";
            StatusTB.Text = "Status";

        }

        private void nameTB_MouseClick(object sender, MouseEventArgs e)
        {
            classTB.Text = "Class";
            SpeciesTB.Text = "Species";
            nameTB.Clear();
            StatusTB.Text = "Status";
        }

        private void SpeciesTB_MouseClick(object sender, MouseEventArgs e)
        {
            classTB.Text = "Class";
            SpeciesTB.Clear();
            nameTB.Text = "Name";
            StatusTB.Text = "Status";
        }
        private void SpeciesTB_MouseClick_1(object sender, MouseEventArgs e)
        {
            classTB.Text = "Class";
            SpeciesTB.Clear();
            nameTB.Text = "Name";
            StatusTB.Text = "Status";
        }

        private void searchPanel_Paint(object sender, PaintEventArgs e)
        {
            classTB.Text = "Class";
            SpeciesTB.Text = "Species";
            nameTB.Text = "Name";
            StatusTB.Text = "Status";
            string selectString = "SELECT Class,Name,Species,Status FROM uptodeal_ZooDatabase.Animal WHERE Class LIKE @parm";
            string parmSt = "%";
            searchAnimal(selectString, parmSt);
        }

        private void SpeciesTB_TextChanged(object sender, EventArgs e)
        {
            string selectString = "SELECT Class,Name,Species,Status FROM uptodeal_ZooDatabase.Animal WHERE Species LIKE @parm";
            string parmSt = SpeciesTB.Text + "%";
            searchAnimal(selectString, parmSt);
        }

        private void StatusTB_MouseClick(object sender, MouseEventArgs e)
        {
            classTB.Text = "Class";
            SpeciesTB.Text = "Species";
            nameTB.Text = "Name";
            StatusTB.Clear();
        }

        private void StatusTB_TextChanged(object sender, EventArgs e)
        {
            string selectString = "SELECT Class,Name,Species,Status FROM uptodeal_ZooDatabase.Animal WHERE Status LIKE @parm";
            string parmSt = StatusTB.Text + "%";
            searchAnimal(selectString, parmSt);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}