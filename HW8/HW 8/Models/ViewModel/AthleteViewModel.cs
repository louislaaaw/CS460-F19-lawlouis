using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HW_8.Models;

namespace HW_8.Models.ViewModel
{
    public class AthleteViewModel
    {
        public class ResultViewModel
        {
            public DateTime? MeetDate { get; set; }

            public int? EventTitle { get; set; }
        
            public string MeetTitle { get; set; }

            public float? Time { get; set; }
        };
        
        public IEnumerable<ResultViewModel> ResultList { get; private set; }
        
        public AthleteViewModel(Athlete athlete)
        {
            
            ResultList = athlete.Results.Select(a => new ResultViewModel
            {
                MeetDate = a.Event.Date,
                EventTitle = a.Event.Distance,
                MeetTitle = a.Event.Location,
                Time = a.Time
            }).OrderByDescending(r => r.EventTitle).ThenByDescending(r => r. MeetDate).ToList();
            AthleteName = athlete.AthleteName;
            Gender = athlete.Gender;
            Team = athlete.Team.TeamName;
        }

        public string AthleteName { get; set; }

        public string Gender { get; set; }

        public string Team { get; set; }

    }
}