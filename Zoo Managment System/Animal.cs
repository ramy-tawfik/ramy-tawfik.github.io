using System;

namespace Zoo_Management_System
{
    // class to save animal data
    public enum AnimalStatus
    {
        Normal,
        ExtinctInTheWild,
        Vulnerable,
        NearThreatened,
        Endangered,
        LeastConcern,
        CriticallyEndangered
    }

    public enum AnimalClass
    {
        Amphibian,
        Bird,
        Mammal,
        Reptile
    }

    public class Animal
    {
        private int ID;
        private AnimalClass animalClass;
        private string animalName;
        private string species;
        private string gender;
        private AnimalStatus status;
        private DateTime lastFeed;

        public int AnimalID { get => ID; set => ID = value; }
        public string AnimalName { get => animalName; set => animalName = value; }
        public string Species { get => species; set => species = value; }
        public AnimalStatus Status { get => status; set => status = value; }
        public DateTime LastFeed { get => lastFeed; set => lastFeed = value; }
        public AnimalClass AnimalClass { get => animalClass; set => animalClass = value; }
        public string Gender { get => gender; set => gender = value; }

        public override string ToString()
        {
            string animalSt;

            animalSt = string.Format("{0,-25}: {1}\t\n{2,-25}: {3}\t\n{4,-25}: {5}\t\n{6,-25}: {7}\t\n{8,-25}: {9}\t\n{10,-25}: {11}\t\n",
                        "Animal Name", animalName,
                        "Animal Class", animalClass.ToString(),
                        "Animal Species", species.ToString(),
                        "Animal Status", status.ToString(),
                        "Animal Gender", gender,
                        "Last Feed", lastFeed.ToString());

            return animalSt;
        }
    }
}