using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Windows.Forms;
using Zoo_Management_System;

namespace Zoo_Managment_System
{
    public partial class updateAnimalForm : Form
    {
        private int animalID = 0;
        public bool animalUpdated = false;

        public updateAnimalForm(ArrayList animalList, Animal selectedAnimal)
        {
            InitializeComponent();

            animalID = selectedAnimal.animalID;
            // Populate class combo box items
            foreach (var item in Enum.GetValues(typeof(animalClass)))
            {
                classComboBox.Items.Add(item.ToString());
            }
            // Populate status combo box items
            foreach (var item in Enum.GetValues(typeof(animalStatus)))
            {
                statusComboBox.Items.Add(item.ToString());
            }
            // Populate Species combo box items
            foreach (Animal item in animalList)
            {
                // set animal status
                if (!speciesComboBox.Items.Contains(item.Species))
                {
                    speciesComboBox.Items.Add(item.Species);
                }
            }

            NameTB.Text = selectedAnimal.AnimalName;
            lastFeedDTPicker.Value = selectedAnimal.LastFeed;
            classComboBox.SelectedItem = selectedAnimal.AnimalClass.ToString();
            statusComboBox.SelectedItem = selectedAnimal.Status.ToString();
            speciesComboBox.SelectedItem = selectedAnimal.Species.ToString();
            GenderComboBox.SelectedItem = selectedAnimal.Gender;
        }

        [Obsolete]
        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (NameTB.Text.Length < 1)
            {
                MessageBox.Show("Please Fill All Required Fields          ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string selectQuery = "UPDATE uptodeal_ZooDatabase.Animal SET Class = @class, Species=@species,Status=@status, Name=@name, Gender=@gender, LastFeed=@lastFeed WHERE ID = @animalID";

                    command = new MySqlCommand(selectQuery, cnn);

                    command.Parameters.Add("@name", MySqlDbType.Text);
                    command.Parameters["@name"].Value = NameTB.Text;

                    command.Parameters.Add("@class", MySqlDbType.Text);
                    command.Parameters["@class"].Value = classComboBox.SelectedItem.ToString();

                    command.Parameters.Add("@species", MySqlDbType.Text);
                    command.Parameters["@species"].Value = speciesComboBox.SelectedItem.ToString();

                    command.Parameters.Add("@status", MySqlDbType.Text);
                    command.Parameters["@status"].Value = statusComboBox.SelectedItem.ToString();

                    command.Parameters.Add("@gender", MySqlDbType.Text);
                    command.Parameters["@gender"].Value = GenderComboBox.SelectedItem.ToString();

                    command.Parameters.Add("@lastFeed", MySqlDbType.Datetime);
                    command.Parameters["@lastFeed"].Value = lastFeedDTPicker.Value;

                    command.Parameters.Add("@animalID", MySqlDbType.Int16);
                    command.Parameters["@animalID"].Value = animalID;

                    cnn.Open();
                    mdr = command.ExecuteReader();

                    cnn.Close();
                    animalUpdated = true;
                    MessageBox.Show("Updated successfully      ");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        // set dateTime picker to current date and time
        private void nowBtn_Click(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
            lastFeedDTPicker.Value = DateTime.Now;
        }
    }
}