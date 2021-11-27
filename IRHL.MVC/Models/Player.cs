using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IRHL.MVC.Models
{
    public class Player
    {
        [Key]
        public int PlayerID { get; set; }

        //FK
        [ForeignKey(nameof(TeamNavigation))]
        public int TeamID { get; set; }

        //Nav Prop
        public virtual Team TeamNavigation { get; set; }


        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName 
        {
            get
            {
                return FirstName + " " + LastName;
            } 
        }

        public bool IsGoalie { get; set; }

        public bool WillGoalie { get; set; }

        //Phone Number
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}