using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Zoo_Managment_System
{
    public partial class ZooKeeperForm : Form
    {
        public ZooKeeperForm(User user)
        {
            InitializeComponent();
        }

        private void ZooKeeperForm_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            ClassComboBox.SelectedIndex = 0;
            statusComboBox.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=96.125.160.33;database=uptodeal_ZooDatabase;uid=uptodeal_ZooApp;pwd=ZooAppPass@;";
            cnn = new MySqlConnection(connetionString);

            try
            {
                
                MessageBox.Show("Connection opend");
                
                MySqlCommand command;
                MySqlDataReader mdr;
                string selectQuery = "SELECT * FROM uptodeal_ZooDatabase.Animal WHERE Class = @animalClass";
                command = new MySqlCommand(selectQuery, cnn);
                command.Parameters.Add("@animalClass",MySqlDbType.Text);
                command.Parameters["@animalClass"].Value = ClassComboBox.SelectedItem.ToString(); 

                cnn.Open();
                mdr = command.ExecuteReader();

                dataGridView1.Rows.Clear();
                while (mdr.Read())
                {
                    dataGridView1.Rows.Add(mdr.GetString("Class"), mdr.GetString("Species"));
                   // testString += (mdr.GetString("Class") + "\t" + mdr.GetString("Species") +"\n");

                }
                



                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
    }
}
