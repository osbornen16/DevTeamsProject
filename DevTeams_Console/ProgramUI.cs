using DevTeams_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Console
{
    class ProgramUI
    {
        private DeveloperRepo _developerDir = new DeveloperRepo();
        private DevTeamRepo _devTeamDir = new DevTeamRepo();
        public void Run()
        {
            SeedData();
            RunMainMenu();
        }
        private void RunMainMenu()
        {
            bool IsRunning = true;
            while (IsRunning == true)
            {
                MainMenuScreen();
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        RunDeveloperMenu();
                        break;
                    case "2":
                        RunDevTeamMenu();
                        break;
                    case "3":
                        RunAddRemoveDevMenu();
                        break;
                    case "4":
                        DevsNeedingPluralSight();
                        Console.WriteLine("\nPress any key to return to main menu...");
                        Console.ReadKey();
                        break;
                    case "5":
                        IsRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 4\n" +
                                "Press any key to try again");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void RunDeveloperMenu()
        {
            bool isRunning = true;
            while (isRunning == true)
            {
                DevMenuScreen();
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddNewDeveloper();
                        break;
                    case "2":
                        ViewDeveloperDir();
                        Console.WriteLine("Press any key to return to the previous menu...");
                        Console.ReadKey();
                        break;
                    case "3":
                        LookUpDevById();
                        Console.WriteLine("Press any key to return to the previous menu...");
                        Console.ReadKey();
                        break;
                    case "4":
                        UpdateDevInfo();
                        Console.WriteLine("Press any key to return to the previous menu...");
                        Console.ReadKey();
                        break;
                    case "5":
                        DeleteDev();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 6\n" +
                                "Press any key to try again");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void RunDevTeamMenu()
        {
            bool isRunning = true;
            while (isRunning == true)
            {
                DevTeamMenuScreen();
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddNewDevTeam();
                        break;
                    case "2":
                        ViewDevTeamDir();
                        Console.WriteLine("Press any key to return to the previous menu...");
                        Console.ReadKey();
                        break;
                    case "3":
                        LookUpDevTeamById();
                        Console.WriteLine("Press any key to return to the previous menu...");
                        Console.ReadKey();
                        break;
                    case "4":
                        UpdateDevTeamInfo();
                        Console.WriteLine("Press any key to return to the previous menu...");
                        Console.ReadKey();
                        break;
                    case "5":
                        DeleteDevTeam();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 6\n" +
                                "Press any key to try again");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void RunAddRemoveDevMenu()
        {
            bool isRunning = true;
            while (isRunning == true)
            {
                AddRemoveMenuScreen();
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddDevToTeam();
                        Console.WriteLine("Press any key to return to the previous menu...");
                        Console.ReadKey();
                        break;
                    case "2":
                        RemoveDevFromTeam();
                        Console.WriteLine("Press any key to return to the previous menu...");
                        Console.ReadKey();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 3\n" +
                                "Press any key to try again");
                        Console.ReadKey();
                        break;
                }
            }
        }
        //Developer methods
        private void AddNewDeveloper()
        {
            Developer developer = new Developer();
            Console.Clear();
            Console.WriteLine("Enter First Name:");
            developer.FirstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name:");
            developer.LastName = Console.ReadLine();
            Console.WriteLine("Enter developer ID Number:");
            developer.IdNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Does the developer have access to Pluralsight?\n" +
                "Type yes/no");

            bool isRunning2 = true;
            while (isRunning2 == true)
            {
                string userInput2 = Console.ReadLine().ToLower();
                switch (userInput2)
                {
                    case "yes":
                        developer.PluralSightAccess = true;
                        isRunning2 = false;
                        break;
                    case "no":
                        developer.PluralSightAccess = false;
                        isRunning2 = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid response");
                        break;
                }
            }
            _developerDir.Addto_DevelopersDir(developer);
            Console.WriteLine("Entry saved...Press any key to return to menu.");
            Console.ReadKey();
        }
        private void ViewDeveloperDir()
        {
            Console.Clear();
            List<Developer> developerList = _developerDir.View_DeveloperDir();
            foreach (Developer developer in developerList)
            {
                Console.WriteLine($"Name: {developer.FullName}\n" +
                    $"ID Number: {developer.IdNumber}\n" +
                    $"Team ID: {developer.TeamID}");
                if (developer.PluralSightAccess == true)
                {
                    Console.Write("Has access to PluralSight: yes\n");
                    Console.WriteLine("");
                }
                else if (developer.PluralSightAccess == false)
                {
                    Console.Write("Has access to PluralSight: no\n");
                    Console.WriteLine("");
                }
            }
        }
        private void LookUpDevById()
        {
            Console.Clear();
            Console.WriteLine("Enter the ID number of a developer to view info...");
            int userInput = int.Parse(Console.ReadLine());
            Console.Clear();
            Developer developer = _developerDir.LookUpDeveloperById(userInput);
            if (developer != null)
            {
                Console.WriteLine($"Developer Name: {developer.FullName}\n" +
                    $"ID Number: {developer.IdNumber}\n" +
                    $"Team ID: {developer.TeamID}");
                if (developer.PluralSightAccess == true)
                {
                    Console.Write("Has access to PluralSight: yes\n");
                    Console.WriteLine("");
                }
                else if (developer.PluralSightAccess == false)
                {
                    Console.Write("Has access to PluralSight: no\n");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("Developer not listed.");
            }
        }
        private void UpdateDevInfo()
        {
            Console.Clear();
            Console.WriteLine("Enter a developer Id Number...");
            int userInput = int.Parse(Console.ReadLine());
            Console.Clear();
            Developer targetDeveloper = _developerDir.LookUpDeveloperById(userInput);
            if (targetDeveloper == null)
            {
                Console.WriteLine("Developer could not be found.\n");
                return;
            }
            Developer updatedDeveloper = new Developer();
            Console.WriteLine($"Id Number: {targetDeveloper.IdNumber}\n" +
                $"First Name: {targetDeveloper.FirstName}\n" +
                $"Last Name: {targetDeveloper.LastName}");
            if (targetDeveloper.PluralSightAccess == true)
            {
                Console.Write("Has access to PluralSight: yes\n");
                Console.WriteLine("");
            }
            else if (targetDeveloper.PluralSightAccess == false)
            {
                Console.Write("Has access to PluralSight: no\n");
                Console.WriteLine("");
            }
            Console.WriteLine("Enter new ID Number:");
            updatedDeveloper.IdNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new First Name:");
            updatedDeveloper.FirstName = Console.ReadLine();
            Console.WriteLine("Enter new Last Name:");
            updatedDeveloper.LastName = Console.ReadLine();
            Console.WriteLine("Give Access to Pluralsight? (yes/no)\n");
            bool isRunning2 = true;
            while (isRunning2 == true)
            {
                string userInput2 = Console.ReadLine().ToLower();
                switch (userInput2)
                {
                    case "yes":
                        updatedDeveloper.PluralSightAccess = true;
                        isRunning2 = false;
                        break;
                    case "no":
                        updatedDeveloper.PluralSightAccess = false;
                        isRunning2 = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid response");
                        break;
                }
            }
            updatedDeveloper.TeamID = targetDeveloper.TeamID;
            _developerDir.UpdateDeveloperInfo(targetDeveloper, updatedDeveloper);
            Console.WriteLine("\nUpdate successful.");
        }
        private void DeleteDev()
        {
            Console.Clear();
            Console.WriteLine("Enter a developer ID number:");
            int userInput = int.Parse(Console.ReadLine());
            Console.Clear();
            Developer targetDeveloper = _developerDir.LookUpDeveloperById(userInput);
            if (targetDeveloper == null)
            {
                Console.WriteLine("Developer could not be found.\n" +
                    "Press any key to return to previous menu...");
                Console.ReadKey();
                return;
            }
            Console.WriteLine($"Name: {targetDeveloper.FullName}\n" +
                $"ID Number: {targetDeveloper.IdNumber}\n" +
                $"Team ID: {targetDeveloper.TeamID}");
            if (targetDeveloper.PluralSightAccess == true)
            {
                Console.Write("Has access to PluralSight: yes\n");
                Console.WriteLine("");
            }
            else if (targetDeveloper.PluralSightAccess == false)
            {
                Console.Write("Has access to PluralSight: no\n");
                Console.WriteLine("");
            }
            Console.WriteLine("Delete developer from directory?(yes/no)");
            Developer devToRemove = targetDeveloper;
            int iDOfDevToRemove = targetDeveloper.TeamID;
            bool isRunning2 = true;
            while (isRunning2 == true)
            {
                string userInput2 = Console.ReadLine().ToLower();
                switch (userInput2)
                {
                    case "yes":
                        _developerDir.DeleteDeveloper(targetDeveloper);
                        //remove deleted dev from team member list
                        DevTeam targetDevTeam = _devTeamDir.LookUpDevTeamById(iDOfDevToRemove);
                        DevTeam updatedDevTeam = new DevTeam();
                        updatedDevTeam.TeamId = targetDevTeam.TeamId;
                        updatedDevTeam.TeamName = targetDevTeam.TeamName;
                        updatedDevTeam.TeamMemberList = targetDevTeam.TeamMemberList;
                        updatedDevTeam.TeamMemberList.Remove(devToRemove);
                        _devTeamDir.UpdateDevTeamInfo(targetDevTeam, updatedDevTeam);
                        Console.Clear();
                        Console.WriteLine($"Developer \"ID: {targetDeveloper.IdNumber}\" successfully deleted.\n" +
                            "Press any key to return to previous menu...");
                        Console.ReadKey();
                        isRunning2 = false;
                        break;
                    case "no":
                        Console.Clear();
                        Console.WriteLine($"Developer \"ID: {targetDeveloper.IdNumber}\" was not deleted.");
                        Console.WriteLine("Press any key to return to previous menu...");
                        Console.ReadKey();
                        isRunning2 = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid response");
                        break;
                }
            }
        }
        //devTeam methods
        private void AddNewDevTeam()
        {
            DevTeam devTeam = new DevTeam();
            Console.Clear();
            Console.WriteLine("Enter Team Name:");
            devTeam.TeamName = Console.ReadLine();
            Console.WriteLine("Enter Team ID number:");
            devTeam.TeamId = int.Parse(Console.ReadLine());
            _devTeamDir.Addto_DevTeamsDir(devTeam);
            Console.WriteLine("To Add Team Members, return to main menu.");
            Console.WriteLine("\nEntry saved...Press any key to return to previous menu.");
            Console.ReadKey();
        }
        private void ViewDevTeamDir()
        {
            Console.Clear();
            List<DevTeam> devTeamList = _devTeamDir.View_DevTeamDir();
            foreach (DevTeam devTeam in devTeamList)
            {
                Console.WriteLine($"Team Name: {devTeam.TeamName}\n" +
                    $"ID Number: {devTeam.TeamId}\n" +
                    $"Team Members: ");
                foreach (Developer teamMember in devTeam.TeamMemberList)
                {
                    Console.Write($"{teamMember.FullName}\n");
                }
                Console.WriteLine("");
            }
        }
        private void LookUpDevTeamById()
        {
            Console.Clear();
            Console.WriteLine("Enter the Team ID Number to view Info...");
            int userInput = int.Parse(Console.ReadLine());
            Console.Clear();
            DevTeam devTeam = _devTeamDir.LookUpDevTeamById(userInput);
            if (devTeam != null)
            {
                Console.WriteLine($"Team Name: {devTeam.TeamName}\n" +
                                    $"ID Number: {devTeam.TeamId}\n" +
                                    $"Team Members: ");
                foreach (Developer teamMember in devTeam.TeamMemberList)
                {
                    Console.Write($"{teamMember.FullName}\n");
                }
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Team not listed.");
            }
        }
        private void UpdateDevTeamInfo()
        {
            Console.Clear();
            List<DevTeam> devTeamList = _devTeamDir.View_DevTeamDir();
            foreach (DevTeam devTeam in devTeamList)
            {
                Console.WriteLine($"Team Name: {devTeam.TeamName}\n" +
                    $"ID Number: {devTeam.TeamId}\n");
            }
            Console.WriteLine("Enter a Team Id Number...");
            int userInput = int.Parse(Console.ReadLine());
            Console.Clear();
            DevTeam targetDevTeam = _devTeamDir.LookUpDevTeamById(userInput);
            if (targetDevTeam == null)
            {
                Console.WriteLine("Team could not be found.\n");
                return;
            }
            DevTeam updatedDevTeam = new DevTeam();
            Console.WriteLine($"ID Number: {targetDevTeam.TeamId}\n" +
                $"Team Name: {targetDevTeam.TeamName}\n");
            Console.WriteLine("Enter new ID Number:");
            updatedDevTeam.TeamId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new Team Name:");
            updatedDevTeam.TeamName = Console.ReadLine();
            updatedDevTeam.TeamMemberList = targetDevTeam.TeamMemberList;
            int targetTeamId = targetDevTeam.TeamId;
            _devTeamDir.UpdateDevTeamInfo(targetDevTeam, updatedDevTeam);
            List<Developer> developerList = _developerDir.View_DeveloperDir();
            foreach (Developer targetDeveloper in developerList)
            {
                Developer updatedDeveloper = new Developer();
                if (targetDeveloper.TeamID == targetTeamId)
                {
                    updatedDeveloper.FirstName = targetDeveloper.FirstName;
                    updatedDeveloper.LastName = targetDeveloper.LastName;
                    updatedDeveloper.IdNumber = targetDeveloper.IdNumber;
                    updatedDeveloper.PluralSightAccess = targetDeveloper.PluralSightAccess;
                    updatedDeveloper.TeamID = updatedDevTeam.TeamId;
                    _developerDir.UpdateDeveloperInfo(targetDeveloper, updatedDeveloper);
                }
            }
            Console.WriteLine("\nUpdate successful.");
            Console.WriteLine("\nTo Add/Remove Team Members, return to the main menu.");
        }
        private void DeleteDevTeam()
        {
            Console.Clear();
            Console.WriteLine("Enter a Team ID number:");
            int userInput = int.Parse(Console.ReadLine());
            Console.Clear();
            DevTeam targetDevTeam = _devTeamDir.LookUpDevTeamById(userInput);
            if (targetDevTeam == null)
            {
                Console.WriteLine("Team could not be found.\n" +
                    "Press any key to return to previous menu...");
                Console.ReadKey();
                return;
            }
            Console.WriteLine($"Name: {targetDevTeam.TeamName}\n" +
                $"ID Number: {targetDevTeam.TeamId}\n" +
                $"Team Members: ");
            foreach (Developer teamMember in targetDevTeam.TeamMemberList)
            {
                Console.Write($"{teamMember.FullName}\n");
            }
            Console.WriteLine("");
            Console.WriteLine("Delete Team from Directory?(yes/no)");
            int targetID = targetDevTeam.TeamId;
            bool isRunning2 = true;
            while (isRunning2 == true)
            {
                string userInput2 = Console.ReadLine().ToLower();
                switch (userInput2)
                {
                    case "yes":
                        _devTeamDir.DeleteDevTeam(targetDevTeam);
                        List<Developer> developerList = _developerDir.View_DeveloperDir();
                        foreach (Developer targetDeveloper in developerList)
                        {
                            if (targetDeveloper.TeamID == targetID)
                            {
                                Developer updatedDeveloper = new Developer();
                                updatedDeveloper.FirstName = targetDeveloper.FirstName;
                                updatedDeveloper.LastName = targetDeveloper.FirstName;
                                updatedDeveloper.IdNumber = targetDeveloper.IdNumber;
                                updatedDeveloper.PluralSightAccess = targetDeveloper.PluralSightAccess;
                                updatedDeveloper.TeamID = 0;
                                _developerDir.UpdateDeveloperInfo(targetDeveloper, updatedDeveloper);
                            }
                        }
                        Console.Clear();
                        Console.WriteLine($"Team \"ID: {targetDevTeam.TeamId}\" successfully deleted.\n" +
                            "Press any key to return to previous menu...");
                        Console.ReadKey();
                        isRunning2 = false;
                        break;
                    case "no":
                        Console.Clear();
                        Console.WriteLine($"Team \"ID: {targetDevTeam.TeamId}\" was not deleted.");
                        Console.WriteLine("Press any key to return to previous menu...");
                        Console.ReadKey();
                        isRunning2 = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid response");
                        break;
                }
            }

        }
        //Add/Remove methods
        private void AddDevToTeam()
        {
            Console.Clear();
            List<Developer> developerList = _developerDir.View_DeveloperDir();
            foreach (Developer developer in developerList)
            {
                Console.WriteLine($"Name: {developer.FullName}\n" +
                    $"ID Number: {developer.IdNumber}\n" +
                    $"Team ID: {developer.TeamID}");
                if (developer.PluralSightAccess == true)
                {
                    Console.Write("Has access to PluralSight: yes\n");
                    Console.WriteLine("");
                }
                else if (developer.PluralSightAccess == false)
                {
                    Console.Write("Has access to PluralSight: no\n");
                    Console.WriteLine("");
                }
            }
            Console.WriteLine("Enter a developer Id Number:");
            int userInput = int.Parse(Console.ReadLine());
            Developer targetDeveloper = _developerDir.LookUpDeveloperById(userInput);
            if (targetDeveloper == null)
            {
                Console.WriteLine("Developer could not be found.\n");
                return;
            }
            Console.Clear();
            Console.WriteLine($"To add the developer to a team, enter a valid Team ID Number:");
            Developer updatedDeveloper = new Developer();
            int userInput2 = int.Parse(Console.ReadLine());
            updatedDeveloper.TeamID = userInput2;
            updatedDeveloper.FirstName = targetDeveloper.FirstName;
            updatedDeveloper.LastName = targetDeveloper.LastName;
            updatedDeveloper.IdNumber = targetDeveloper.IdNumber;
            updatedDeveloper.PluralSightAccess = targetDeveloper.PluralSightAccess;
            _developerDir.UpdateDeveloperInfo(targetDeveloper, updatedDeveloper);
            DevTeam targetDevTeam = _devTeamDir.LookUpDevTeamById(userInput2);
            DevTeam updatedDevTeam = new DevTeam();
            updatedDevTeam.TeamId = targetDevTeam.TeamId;
            updatedDevTeam.TeamName = targetDevTeam.TeamName;
            updatedDevTeam.TeamMemberList = targetDevTeam.TeamMemberList;
            updatedDevTeam.TeamMemberList.Add(updatedDeveloper);
            _devTeamDir.UpdateDevTeamInfo(targetDevTeam, updatedDevTeam);
            Console.WriteLine($"{ updatedDeveloper.FullName} was added to team: { updatedDevTeam.TeamName}");
        }
        private void RemoveDevFromTeam()
        {
            Console.Clear();
            List<Developer> developerList = _developerDir.View_DeveloperDir();
            foreach (Developer developer in developerList)
            {
                Console.WriteLine($"Name: {developer.FullName}\n" +
                    $"ID Number: {developer.IdNumber}\n" +
                    $"Team ID: {developer.TeamID}");
                if (developer.PluralSightAccess == true)
                {
                    Console.Write("Has access to PluralSight: yes\n");
                    Console.WriteLine("");
                }
                else if (developer.PluralSightAccess == false)
                {
                    Console.Write("Has access to PluralSight: no\n");
                    Console.WriteLine("");
                }
            }
            Console.WriteLine("Enter a developer Id Number:");
            int userInput = int.Parse(Console.ReadLine());
            Developer targetDeveloper = _developerDir.LookUpDeveloperById(userInput);
            if (targetDeveloper == null)
            {
                Console.WriteLine("Developer could not be found.\n");
                return;
            }
            else if (targetDeveloper.TeamID < 1)
            {
                Console.WriteLine("Developer currently not assigned to a team.");
                return;
            }
            Console.Clear();
            Console.WriteLine($"{targetDeveloper.FullName} is assigned to team: {targetDeveloper.TeamID}\n" +
                $"Remove {targetDeveloper.FullName} from team? (yes/no)");
            int iDOfDevToRemove = targetDeveloper.TeamID;
            bool isRunning = true;
            while (isRunning == true)
            {
                string YesNoInput = Console.ReadLine().ToLower();
                switch (YesNoInput)
                {
                    case "yes":
                        Developer updatedDeveloper = new Developer();
                        updatedDeveloper.TeamID = 0;
                        updatedDeveloper.FirstName = targetDeveloper.FirstName;
                        updatedDeveloper.LastName = targetDeveloper.LastName;
                        updatedDeveloper.IdNumber = targetDeveloper.IdNumber;
                        updatedDeveloper.PluralSightAccess = targetDeveloper.PluralSightAccess;
                        _developerDir.UpdateDeveloperInfo(targetDeveloper, updatedDeveloper);
                        DevTeam targetDevTeam = _devTeamDir.LookUpDevTeamById(iDOfDevToRemove);
                        Developer updatedDevToRemove = _developerDir.LookUpDeveloperById(userInput);
                        DevTeam updatedDevTeam = new DevTeam();
                        updatedDevTeam.TeamId = targetDevTeam.TeamId;
                        updatedDevTeam.TeamName = targetDevTeam.TeamName;
                        updatedDevTeam.TeamMemberList = targetDevTeam.TeamMemberList;
                        updatedDevTeam.TeamMemberList.Remove(updatedDevToRemove);
                        _devTeamDir.UpdateDevTeamInfo(targetDevTeam, updatedDevTeam);
                        Console.WriteLine($"{updatedDevToRemove.FullName} was successfully removed.");
                        isRunning = false;
                        break;
                    case "no":
                        Console.WriteLine("No changes were made.");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid reponse...");
                        break;
                }
            }
        }
        //get list of Developers in need of PluralSight
        private void DevsNeedingPluralSight()
        {
            Console.Clear();
            List<Developer> developerList = _developerDir.View_DeveloperDir();
            foreach (Developer developer in developerList)
            {
                if(developer.PluralSightAccess == false)
                {
                    Console.WriteLine($"{developer.FullName} #{developer.IdNumber}");
                }
            }
        }
        //helper methods -- menus screens
        public void MainMenuScreen()
        {
            Console.Clear();
            Console.WriteLine($"1. Developer Info Menu\n" +
                $"2. Developer Team Info Menu\n" +
                $"3. Add/Remove developers from teams\n" +
                $"4. View list of developers without access to PluralSight\n" +
                $"5. Exit\n");
            Console.WriteLine("Type the number of the menu option to select:");
        }
        public void DevMenuScreen()
        {
            Console.Clear();
            Console.WriteLine($"1. Add new developer\n" +
                $"2. View directory\n" +
                $"3. Look up developer by ID number\n" +
                $"4. Update developer info\n" +
                $"5. Remove developer from directory\n" +
                $"6. Return to main menu\n");
            Console.WriteLine("Type the number of the menu option to select:");
        }
        public void DevTeamMenuScreen()
        {
            Console.Clear();
            Console.WriteLine($"1. Add New Team\n" +
                $"2. View directory\n" +
                $"3. Look up Team by ID Number\n" +
                $"4. Update Team info\n" +
                $"5. Remove Team from Directory\n" +
                $"6. Return to main menu\n");
            Console.WriteLine("Type the number of the menu option to select:");
        }
        public void AddRemoveMenuScreen()
        {
            Console.Clear();
            Console.WriteLine($"1. Add Developer to a Team\n" +
                $"2. Remove Developer from a Team\n" +
                $"3. Return to main menu\n");
            Console.WriteLine("Type the number of the menu option to select:");
        }
        //SeedData
        public void SeedData()
        {
            List<Developer> team1 = new List<Developer>();
            List<Developer> team2 = new List<Developer>();
            List<Developer> team3 = new List<Developer>();
            Developer seed1 = new Developer("Bob", "McBob", 200, 100, true);
            Developer seed2 = new Developer("Joe", "McJoe", 200, 101, true);
            Developer seed3 = new Developer("Sally", "McSally", 200, 102, false);
            _developerDir.Addto_DevelopersDir(seed1);
            _developerDir.Addto_DevelopersDir(seed2);
            _developerDir.Addto_DevelopersDir(seed3);
            DevTeam teamSeed1 = new DevTeam("Colts", 200, team1);
            teamSeed1.TeamMemberList.Add(seed1);
            teamSeed1.TeamMemberList.Add(seed2);
            teamSeed1.TeamMemberList.Add(seed3);
            DevTeam teamSeed2 = new DevTeam("Packers", 201, team2);
            DevTeam teamSeed3 = new DevTeam("Steelers", 202, team3);
            _devTeamDir.Addto_DevTeamsDir(teamSeed1);
            _devTeamDir.Addto_DevTeamsDir(teamSeed2);
            _devTeamDir.Addto_DevTeamsDir(teamSeed3);
        }
    }
}
