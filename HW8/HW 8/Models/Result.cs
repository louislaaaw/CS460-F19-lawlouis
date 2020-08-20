namespace HW_8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Result
    {
        public int ResultID { get; set; }

        public int AthleteID { get; set; }

        public int EventID { get; set; }

        public float? Time { get; set; }

        public virtual Athlete Athlete { get; set; }

        public virtual Event Event { get; set; }
    }
}
