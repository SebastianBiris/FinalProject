using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using ControllerLayer;
using ModelLayer;
using InterfaceLayer;

using System.Diagnostics;

namespace Test
{
    [TestClass]
    public class ControllerTest
    {

        [TestMethod]
        public void DbConnection()   //????
        {
            DataAccessDB myDb = new DataAccessDB();

        }

        [TestMethod]
        public void DeleteStaffMemberTest()
        {
            Controller myController = new Controller();
            int expected = myController.NumberOfStaffMembers() - 1;
            myController.DeleteStaffMember(myController.StaffMembers[5].StaffMemeberId);
            myController.GetAllFromDB();
            int actual = myController.NumberOfStaffMembers();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteMessagesTest()
        {

            Controller myController = new Controller();
            int expected = myController.NumberOfMessages() - 1;
            myController.DeleteMessage(myController.Messages[0].MessageId);
            myController.GetAllFromDB();
            int actual = myController.NumberOfMessages();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateNewMessagesTest()
        {

            Controller myController = new Controller();
            int expected = myController.NumberOfMessages() + 1;
            myController.CreateNewMessage("Hey we are unit testing messages", 10);
            myController.GetAllFromDB();
            int actual = myController.NumberOfMessages();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateStaffMember()
        {
            Controller myController = new Controller();
            int expected = myController.NumberOfStaffMembers() + 1;
            myController.CreateStaffMember("Batman", "1809362134", "658387746", "IAMBATMAN.NANANANA@batman.com", "NaNaNaNaNaaa", "Full time. Just can not work on sundays.", 3, 1);
            myController.GetAllFromDB();
            int actual = myController.NumberOfStaffMembers();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UpdateStaffMember()
        {
            Controller myController = new Controller();

            string expected2 = "34532";
            string expected = "Amypip@gmail.com";
            myController.UpdateStaffMember(48, "Amy Johnson", "34532", "42254628", "Amypip@gmail.com", "bwervr", "part time. Weekends only", 2, 2);
            myController.GetAllFromDB();

            Assert.AreEqual(expected, myController.StaffMembers[1].Email);
            Assert.AreEqual(expected2, myController.StaffMembers[1].Cpr);
        }
        [TestMethod]
        public void AddNewShiftDateInDBTest()
        {
            Controller myController = new Controller();
            int expectedListNo = myController.NumberOfShiftDate() + 1;

            myController.AddNewShiftDateInDB(11, 1, 7);
            myController.GetAllFromDB();
            int actual = myController.NumberOfShiftDate();

            Assert.AreEqual(expectedListNo, actual, "this is for checking the count");
        }
    }
}
