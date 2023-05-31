using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuroraAPI.Models
{
    public partial class UserDoseMedicine
    {
        [Key]
        public int Dose_Code { get; set; }
        public int User_Id { get; set; }
        public int Medicine_Code { get; set; }
        public int Number_Of_Pills { get; set; }

        public virtual Doses1 Dose_CodeNavigation { get; set; }
        public virtual Medicine Medicine_CodeNavigation { get; set; }
        public virtual Users User { get; set; }
    }
}
