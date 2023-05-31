using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuroraAPI.Models
{
    public partial class Users
    {
                public Users()
        {
            Ec = new HashSet<Ec>();
            UserPhone = new HashSet<UserPhone>();
        }
        [Key]
        public int User_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string User_Email { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public int password { get; set; }


        public virtual ICollection<Ec> Ec { get; set; }
        public virtual ICollection<UserPhone> UserPhone { get; set; }
    }
}
