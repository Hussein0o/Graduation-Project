using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuroraAPI.Models
{
    public partial class Doses1
    {
        [Key]
        public int Dose_Code { get; set; }
        public TimeSpan Dose_Time { get; set; }
        public DateTime Dose_Date { get; set; }
        public TimeSpan Time_Of_Abuse { get; set; }
        public string time_diffrence { get; set; }

    }
}
