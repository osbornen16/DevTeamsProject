using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repository
{
    public class DevTeamRepo
    {
        //Field
        public List<DevTeam> _devTeamDir = new List<DevTeam>();

        //methods

        //add dev teams to the devTeamsDirectory 
        public void Addto_DevTeamsDir(DevTeam devTeam)
        {
            _devTeamDir.Add(devTeam);
        }
        public List<DevTeam> View_DevTeamDir()
        {
            return _devTeamDir;
        }
        public DevTeam LookUpDevTeamById(int devTeamNumber)
        {
            foreach (DevTeam devTeam in _devTeamDir)
            {
                if (devTeam.TeamId == devTeamNumber)
                {
                    return devTeam;
                }
            }
            return null;
        }
        public void UpdateDevTeamInfo(DevTeam existingContent, DevTeam newContent)
        {
            existingContent.TeamName = newContent.TeamName;
            existingContent.TeamId = newContent.TeamId;
            existingContent.TeamMemberList = newContent.TeamMemberList;
        }
        public void DeleteDevTeam(DevTeam devTeam)
        {
            _devTeamDir.Remove(devTeam);
        }

    }
}
