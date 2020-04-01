using System;

namespace Zoo_Management_System
{
    // class to save animal data
    public enum animalStatus
    {
        Normal,
        ExtinctInTheWild,
        Vulnerable,
        NearThreatened,
        Endangered,
        LeastConcern,
        CriticallyEndangered
    }

    public enum animalClass
    {
        Amphibian,
        Bird,
        Mammal,
        Reptile
    }

    public class Animal
    {
        private int ID;
        private animalClass animalClass;
        private string animalName;
        private string species;
        private string gender;
        private animalStatus status;
        private DateTime lastFeed;

        public int animalID { get => ID; set => ID = value; }
        public string AnimalName { get => animalName; set => animalName = value; }
        public string Species { get => species; set => species = value; }
        public animalStatus Status { get => status; set => status = value; }
        public DateTime LastFeed { get => lastFeed; set => lastFeed = value; }
        public animalClass AnimalClass { get => animalClass; set => animalClass = value; }
        public string Gender { get => gender; set => gender = value; }
    }
}