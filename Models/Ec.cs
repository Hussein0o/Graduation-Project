using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuroraAPI.Models
{
    public partial class Ec
    {
        public Ec()
        {
            ContactPhone = new HashSet<ContactPhone>();
        }

        [Key]
        public int User_Id { get; set; }
        public int Contact_Code { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<ContactPhone> ContactPhone { get; set; }
    }
}
