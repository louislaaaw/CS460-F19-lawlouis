namespace HW_8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class Athlete
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Athlete()
        {
            Results = new HashSet<Result>();
        }

        public int AthleteID { get; set; }

        [Required]
        [StringLength(64)]
        public string AthleteName { get; set; }

        [Required]
        [StringLength(8)]
        public string Gender { get; set; }

        [Display(Name = "Team")]
        public int TeamID { get; set; }

        public virtual Team Team { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result> Results { get; set; }
    }
}
