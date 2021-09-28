using DevTeams_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ProjectTests
{
    [TestClass]
    public class DeveloperTests
    {

        [TestMethod]
        public void FullName_ExpectedAndActualShouldReturnEqual()
        {
            Developer example = new Developer();
            example.FirstName = "Nate";
            example.LastName = "Osborne";

            string fullNameExpected = "Nate Osborne";
            string fullNameActual = example.FullName;

            Assert.AreEqual(fullNameExpected, fullNameActual);
        }

        [TestMethod]
        public void DevTeamPropertyTeamMemberList_ReturnsCorrectNumberOfDevelopers()
        {
            //1
            List<Developer> exampleList = new List<Developer>();

            Developer kathy = new Developer("Kathy", "McKathy", 007, true);
            Developer micky = new Developer("Micky", "McMicky", 008, false);
            Developer james = new Developer("James", "McJames", 009, true);
            exampleList.Add(kathy);
            exampleList.Add(micky);
            exampleList.Add(james);

            //2
            DevTeam teamExample = new DevTeam("Coders", 010, exampleList);

            //act on 1 and 2
            int resultActual1 = teamExample.TeamMemberList.Count; 
            
            int resultActual2 = exampleList.Count;

            int resultExpected = 3;

            Assert.AreEqual(resultActual1, resultExpected);
            Assert.AreEqual(resultActual2, resultExpected);
        }

        [TestMethod]
        public void TryingToTestNumberOfTeamEntiresIntoFieldDirectory()
        {
            /*//1 devteam1 developers
            List<Developer> exampleList1 = new List<Developer>();

            Developer kathy = new Developer("Kathy", "McKathy", 007, true);
            Developer micky = new Developer("Micky", "McMicky", 008, false);
            Developer james = new Developer("James", "McJames", 009, true);
            exampleList1.Add(kathy);
            exampleList1.Add(micky);
            exampleList1.Add(james);

            //2 devteam2 developers
            List<Developer> exampleList2 = new List<Developer>();

            Developer bill = new Developer("bill", "Mcbill", 011, true);
            Developer john = new Developer("john", "Mcjohn", 012, false);
            Developer peter = new Developer("peter", "McJames", 013, true);
            exampleList2.Add(bill);
            exampleList2.Add(john);
            exampleList2.Add(peter);

            DevTeam example1 = new DevTeam("Coders1", 020, exampleList1);
            DevTeam example2 = new DevTeam("Coders1", 020, exampleList2);

            DevTeamRepo devteamsDirectory = new DevTeamRepo();
            devteamsDirectory.Addto_DevTeamsDir(example1);
            devteamsDirectory.Addto_DevTeamsDir(example2);

            int numberofTeamsExpected = 2;
            int numberofTeamsActual = devteamsDir*/
        }
    }
}
