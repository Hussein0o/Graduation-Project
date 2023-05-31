using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuroraAPI.Models
{
    public partial class ContactPhone
    {
      [Key]
        public int Contact_Code { get; set; }
        public string Contact_Phone { get; set; }

        public virtual Ec Contact_CodeNavigation { get; set; }
    }
}
