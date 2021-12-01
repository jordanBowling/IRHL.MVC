using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IRHL.MVC.Models
{
    public class Game
    {
        //Game ID
        [Key]
        public int GameID { get; set; }

        
        //Team 1
        //FK
        //[ForeignKey("Team")]
        public int TeamOneID { get; set; }

        //Nav Prop
        //public virtual ICollection<Team> ListOfTeams { get; set; }

        //public Game()
        //{
        //    ListOfTeams = new HashSet<Team>();
        //}


        public int TeamOneGoals { get; set; }

        [DataType(DataType.Time)]
        public int TeamOnePIM { get; set; }


        //Team 2
        //[ForeignKey("Team")]
        public int TeamTwoID { get; set; }

        //Nav Prop
        //public virtual Team Team { get; set; }

        public int TeamTwoGoals { get; set; }

        [DataType(DataType.Time)]
        public int TeamTwoPIM { get; set; }
    }
}