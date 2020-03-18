using System;

namespace Zoo_Managment_System
{
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

    class Animal
    {
        private int ID;
        private animalClass animalClass;
        private string animalName;
        private string species;
        private animalStatus status;
        private DateTime lastFeed;

        public int ID1 { get => ID; set => ID = value; }
        public string AnimalName { get => animalName; set => animalName = value; }
        public string Species { get => species; set => species = value; }
        public animalStatus Status { get => status; set => status = value; }
        public DateTime LastFeed { get => lastFeed; set => lastFeed = value; }
        public animalClass AnimalClass { get => animalClass; set => animalClass = value; }
    }
}
