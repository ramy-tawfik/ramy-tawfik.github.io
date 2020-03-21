using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Windows.Forms;

namespace Zoo_Managment_System
{
    public partial class ZooKeeperForm : Form
    {
        private ArrayList animalList = new ArrayList();

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
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=96.125.160.33;database=uptodeal_ZooDatabase;uid=uptodeal_ZooApp;pwd=ZooAppPass@;";
            cnn = new MySqlConnection(connetionString);
            MySqlCommand command;
            MySqlDataReader mdr;
            string selectQuery = "SELECT * FROM uptodeal_ZooDatabase.Animal";
            try
            {
                cnn.Open();
                command = new MySqlCommand(selectQuery, cnn);
                mdr = command.ExecuteReader();
                while (mdr.Read())
                {
                    Animal animal = new Animal();
                    // set animal class
                    switch (mdr.GetString("Class"))
                    {
                        case "Amphibian":
                            animal.AnimalClass = Zoo_Managment_System.animalClass.Amphibian;
                            break;

                        case "Bird":
                            animal.AnimalClass = Zoo_Managment_System.animalClass.Bird;
                            break;

                        case "Mammal":
                            animal.AnimalClass = Zoo_Managment_System.animalClass.Mammal;
                            break;

                        case "Reptile":
                            animal.AnimalClass = Zoo_Managment_System.animalClass.Reptile;
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
                    // animal.LastFeed = mdr.GetDateTime("LastFeed");

                    animalList.Add(animal);
                }
                cnn.Close();
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
            string classGroup, statusGroup, speciesGroup;
            classGroup = ClassComboBox.SelectedItem.ToString();
            statusGroup = statusComboBox.SelectedItem.ToString();
            speciesGroup = speciesComboBox.SelectedItem.ToString();

            foreach (Animal item in animalList)
            {
                // set animal status
                if (item.AnimalClass.ToString().Equals(classGroup)
                    && item.Status.ToString().Equals(statusGroup)
                    && item.Species.ToString().Equals(speciesGroup)
                    )
                {
                    dataGridView1.Rows.Add(item.AnimalClass, item.AnimalName, item.Species, item.Status);
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
    }
}

/*
string connetionString = null;
MySqlConnection cnn;
connetionString = "server=96.125.160.33;database=uptodeal_ZooDatabase;uid=uptodeal_ZooApp;pwd=ZooAppPass@;";
            cnn = new MySqlConnection(connetionString);
MySqlCommand command;
MySqlDataReader mdr;
string selectQuery = "";

            try
            {
                MessageBox.Show("Connection opend");

                if (ClassComboBox.SelectedItem.ToString().Equals("All")
                    && statusComboBox.SelectedItem.ToString().Equals("All Statuses")
                    && speciesComboBox.SelectedItem.ToString().Equals("ALL"))
                {
                    selectQuery = "SELECT * FROM uptodeal_ZooDatabase.Animal";
                }
                else
                {
                    selectQuery = "SELECT * FROM uptodeal_ZooDatabase.Animal WHERE Class = @animalClass";
                }

                //selectQuery = "SELECT * FROM uptodeal_ZooDatabase.Animal WHERE Class = @animalClass";

                dataGridView1.Rows.Clear();

                cnn.Open();
                command = new MySqlCommand(selectQuery, cnn);
command.Parameters.Add("@animalClass", MySqlDbType.Text);
                command.Parameters["@animalClass"].Value = ClassComboBox.SelectedItem.ToString();

                mdr = command.ExecuteReader();

                //command.Parameters["@animalClass"].Value = "";
                while (mdr.Read())
                {
                    dataGridView1.Rows.Add(mdr.GetString("Class"), mdr.GetString("Species"), mdr.GetString("Status"));
                    // testString += (mdr.GetString("Class") + "\t" + mdr.GetString("Species") +"\n");
                }

                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }*/