using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuroraAPI.Models
{
    public partial class UserPhone
    {
        [Key]
        public int User_Id { get; set; }
        public string User_Phone { get; set; }

        public virtual Users User { get; set; }
    }
}
