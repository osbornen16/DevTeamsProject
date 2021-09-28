using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repository
{
    public class Developer
    {
        //properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName 
        { 
            get 
            {
                string fullName = FirstName + " " + LastName;
                return fullName;
            }
        }
        public int IdNumber { get; set; }
        public bool PluralSightAccess { get; set; }
        //how to add teamID
        public int TeamID { get; set; }
        //constructors
        public Developer () { }
        public Developer (string firstName, string lastName, int idNumber, bool pluralSightAccess)
        {
            FirstName = firstName;
            LastName = lastName;
            IdNumber = idNumber;
            PluralSightAccess = pluralSightAccess;
        }
        public Developer(string firstName, string lastName, int teamID, int idNumber, bool pluralSightAccess)
        {
            FirstName = firstName;
            LastName = lastName;
            IdNumber = idNumber;
            PluralSightAccess = pluralSightAccess;
            TeamID = teamID;
        }



    }
}
