using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Managment_System
{
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

        public int ID1 { get => ID; set => ID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LasttName { get => lastName; set => lastName = value; }
        public userRole Role { get => role; set => role = value; }

        public  string displayName()
        {
            return this.firstName + " " + this.lastName;
        }
    }
}
