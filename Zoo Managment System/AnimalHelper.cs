using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Windows.Forms;
using Zoo_Management_System;

namespace Zoo_Managment_System
{
    internal static class AnimalHelper
    {
        private static string connetionString = null;
        private static MySqlConnection cnn;

        // load animal database into animalArraylist then return the ArrayList
        public static ArrayList GetAnimalList()
        {
            ArrayList animalList = new ArrayList();
            MySqlCommand command;
            MySqlDataReader mdr;
            string selectQuery = "SELECT * FROM uptodeal_ZooDatabase.Animal";
            try
            {
                OpenConnection();
                animalList.Clear();

                command = new MySqlCommand(selectQuery, cnn);
                mdr = command.ExecuteReader();
                while (mdr.Read())
                {
                    Animal animal = new Animal();
                    animal.AnimalID = mdr.GetInt16("ID");
                    // set animal class
                    switch (mdr.GetString("Class"))
                    {
                        case "Amphibian":
                            animal.AnimalClass = Zoo_Management_System.AnimalClass.Amphibian;
                            break;

                        case "Bird":
                            animal.AnimalClass = Zoo_Management_System.AnimalClass.Bird;
                            break;

                        case "Mammal":
                            animal.AnimalClass = Zoo_Management_System.AnimalClass.Mammal;
                            break;

                        case "Reptile":
                            animal.AnimalClass = Zoo_Management_System.AnimalClass.Reptile;
                            break;

                        default:
                            break;
                    }
                    // set animal status
                    switch (mdr.GetString("Status"))
                    {
                        case "Normal":
                            animal.Status = AnimalStatus.Normal;
                            break;

                        case "Extinct In The Wild":
                            animal.Status = AnimalStatus.ExtinctInTheWild;
                            break;

                        case "Vulnerable":
                            animal.Status = AnimalStatus.Vulnerable;
                            break;

                        case "Near Threatened":
                            animal.Status = AnimalStatus.NearThreatened;
                            break;

                        case "Endangered":
                            animal.Status = AnimalStatus.Endangered;
                            break;

                        case "Least Concern":
                            animal.Status = AnimalStatus.LeastConcern;
                            break;

                        case "Critically Endangered":
                            animal.Status = AnimalStatus.CriticallyEndangered;
                            break;

                        default:
                            break;
                    }

                    // add animal info
                    animal.Species = mdr.GetString("Species");
                    animal.AnimalName = mdr.GetString("Name");
                    animal.Gender = mdr.GetString("Gender");

                    animal.LastFeed = (DateTime)mdr.GetMySqlDateTime("LastFeed");

                    animalList.Add(animal);
                }
                CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return animalList;
        }

        // Open connection to Database
        public static void OpenConnection()
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
        public static void CloseConnection()
        {
            if (cnn.State == System.Data.ConnectionState.Open)
            {
                cnn.Close();
            }
        }
    }
}