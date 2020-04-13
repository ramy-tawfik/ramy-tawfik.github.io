namespace Zoo_Management_System
{
    // class to save user data
    //user role Enum
    public enum UserRole
    {
        Admin,
        ZooKeeper
    }

    public class User
    {
        private int ID;
        private string firstName;
        private string lastName;
        private string username;
        private UserRole role;

        public int userID { get => ID; set => ID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public UserRole Role { get => role; set => role = value; }
        public string Username { get => username; set => username = value; }

        public string DisplayName()
        {
            return this.firstName + " " + this.lastName;
        }
    }
}