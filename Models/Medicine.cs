using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuroraAPI.Models
{
    public partial class Medicine
    {
        [Key]
        public int Medicine_Code { get; set; }
        public string Medicine_Name { get; set; }
        public int No_Of_Tapes { get; set; }
        public int No_Of_Pills_In_Tape { get; set; }

    }
}
