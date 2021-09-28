using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repository
{
    public class DeveloperRepo
    {
        //Field
        private readonly List<Developer> _developerDir = new List<Developer>();
        
        //methods
        public void Addto_DevelopersDir(Developer developer)
        {
                _developerDir.Add(developer);
        }
        public List<Developer> View_DeveloperDir()
        {
            return _developerDir;
        }
        public Developer LookUpDeveloperById (int devNumber)
        {
            foreach (Developer developer in _developerDir)  
            {
                if (developer.IdNumber == devNumber)
                {
                    return developer;
                }
            }
            return null;
        }
        public void UpdateDeveloperInfo (Developer existingContent, Developer newContent)
        {
            existingContent.FirstName = newContent.FirstName;
            existingContent.LastName = newContent.LastName;
            existingContent.IdNumber = newContent.IdNumber;
            existingContent.PluralSightAccess = newContent.PluralSightAccess;
            existingContent.TeamID = newContent.TeamID;
        }
        public void DeleteDeveloper (Developer developer)
        {
            _developerDir.Remove(developer);
        }
    }
}
