using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Windows.Forms;

namespace Zoo_Managment_System
{
    public partial class administratorForm : Form
    {
        private readonly User loggeduser;
        private bool animalLoaded = false;
        private ArrayList animalList = new ArrayList();

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
        }


        //  anumals tab selected
        private void taskTwoBtn_Click(object sender, System.EventArgs e)
        {
            tabPanel.Height = taskTwoBtn.Height;
            tabPanel.Top = taskTwoBtn.Top;
            tabcontrol.SelectedTab = animalTab;

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
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = DateTime.Now.ToString();
        }

        private void connectAnimal()
        {
            
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=96.125.160.33;database=uptodeal_ZooDatabase;uid=uptodeal_ZooApp;pwd=ZooAppPass@;";
            cnn = new MySqlConnection(connetionString);

            try
            {
                MySqlCommand command;
                MySqlDataReader mdr;
                string selectQuery = "SELECT * FROM uptodeal_ZooDatabase.Animal";
                command = new MySqlCommand(selectQuery, cnn);

                cnn.Open();
                mdr = command.ExecuteReader();
                progressBar1.Visible = true;
                while (mdr.Read())
                {
                    Animal animal = new Animal();
                    // set animal class
                    switch (mdr.GetString("Class"))
                    {
                        case "Amphibian":
                            animal.AnimalClass = animalClass.Amphibian;
                            break;

                        case "Bird":
                            animal.AnimalClass = animalClass.Bird;
                            break;

                        case "Mammal":
                            animal.AnimalClass = animalClass.Mammal;
                            break;

                        case "Reptile":
                            animal.AnimalClass = animalClass.Reptile;
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
                    // animal.LastFeed = mdr.GetDateTime("LastFeed");

                    animalList.Add(animal);
                    if (progressBar1.Value < progressBar1.Maximum)
                    {
                        progressBar1.Value += 1; //fill the progressbar
                    }
                }

                mdr.Close();
                cnn.Close();
                progressBar1.Visible = false; 
                progressBar1.Value = 0;

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}