using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IRHL.MVC.Models
{
    public class Team
    {
        //Team ID
        [Key]
        public int TeamID { get; set; }

        //Team Name
        public string TeamName { get; set; }

        //Team Captain
        public string TeamCaptain { get; set; }

        //Wins
        public int Wins { get; set; }

        //Losses
        public int Losses { get; set; }

        //OTL
        public int OTLosses { get; set; }

        //Goals For
        public int GoalsFor { get; set; }

        //Goals Against
        public int GoalsAgainst { get; set; }

        //DIFF
        public int GoalDifference { get; set; }

        //Looking for player?
        public bool NeedPlayer { get; set; }

        //List of players

        //Streak (stretch)
        public int Streak { get; set; }

        //PIM (stretch)
    }
}