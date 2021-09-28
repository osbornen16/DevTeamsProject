using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repository
{
    public class DevTeam
    {

        //properties
        public string TeamName { get; set; }
        public int TeamId { get; set; } = -1;
        public List<Developer> TeamMemberList { get; set; } = new List<Developer>();
        //constructors
        public DevTeam() { }
        public DevTeam(string teamName, int teamId)
        {
            TeamName = teamName;
            TeamId = teamId;
        }
        public DevTeam(string teamName, int teamId, List<Developer> teamMemberList)
        {
            TeamName = teamName;
            TeamId = teamId;
            TeamMemberList = teamMemberList;
        }
    }
}
