namespace Zoo_Managment_System
{
    // class to save user data
    //user role enum
    public enum userRole
    {
        Admin,
        ZooKeeper
    }

    public class User
    {
        private int ID;
        private string firstName;
        private string lastName;
        private userRole role;

        public int userID { get => ID; set => ID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public userRole Role { get => role; set => role = value; }

        public string displayName()
        {
            return this.firstName + " " + this.lastName;
        }
    }
}