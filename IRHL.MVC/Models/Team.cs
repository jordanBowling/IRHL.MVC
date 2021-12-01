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
        [Display(Name = "Team Name")]
        public string TeamName { get; set; }

        //Team Captain
        [Display(Name = "Team Captain")]
        public string TeamCaptain { get; set; }

        //Wins
        public int Wins { get; set; }

        //Losses
        public int Losses { get; set; }

        //OTL
        [Display(Name = "OTL")]
        public int OTLosses { get; set; }

        //Goals For
        [Display(Name = "GF")]
        public int GoalsFor { get; set; }

        //Goals Against
        [Display(Name = "GA")]
        public int GoalsAgainst { get; set; }

        //DIFF
        [Display(Name = "DIFF")]
        public int GoalDifference 
        { get
            {
                return GoalsFor - GoalsAgainst;   
            }
        }

        //Looking for player?
        [Display(Name = "Need Player?")]
        public bool NeedPlayer { get; set; }

        //List of players

        //Streak (stretch)
        public int Streak { get; set; }

        //PIM (stretch)

        //Nav for many to many
        //public virtual ICollection<Game> ListOfGames { get; set; }
        //public virtual ICollection<Player> ListOfPlayers { get; set; }

        //public Team()
        //{
        //    ListOfGames = new HashSet<Game>();
        //    ListOfPlayers = new HashSet<Player>();
        //}
    }
}