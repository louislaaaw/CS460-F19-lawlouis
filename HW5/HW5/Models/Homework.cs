using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

/**
 * 	[ID]		INT IDENTITY (1,1)	NOT NULL,
	[Priority]  INT				NOT NULL,
	[DueDate]	DATE		NOT NULL,
	[DueTime]	TIME		NOT NULL,
	[Department] NVARCHAR(32)	NOT NULL,
	[Course]	INT				NOT NULL,
	[HomeworkTitle] NVARCHAR(64)	NOT NULL,
	[Note] NVARCHAR(256) */

namespace HW5.Models
{
    public class Homework
    {
        [Key, Required]
        public int ID { get; set; }

        [Display(Name = "Priority")]
        [Required]
        public int Priority { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "DueDate")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Required]
        public DateTime DueDate { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "DueTime")]
        [Required]
        public TimeSpan DueTime { get; set; }

        [Display(Name = "Department")]
        [Required]
        public string Department { get; set; }

        [Display(Name = "Course")]
        [Required]
        public int Course { get; set; }

        [Display(Name = "HomeworkTitle")]
        [Required]
        public string HomeworkTitle { get; set; }

        [Display(Name = "Note")]
        public string Note { get; set; }

    }
}
