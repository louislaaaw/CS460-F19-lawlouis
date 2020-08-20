using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW_8.Models.ViewModel
{
    public class TeamViewModel
    {
        public class EventResult
        {
            public float? Time { get; set; }

            public DateTime? Date { get; set; }

            public string Distance { get; set; }
        }

        public IEnumerable<EventResult> EventList { get; set; }

        public TeamViewModel(Team team)
        {

        }

        public string AthleteName { get; set; }

        public string TeamName { get; set; }

    }
}