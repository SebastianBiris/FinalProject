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

            string expectedCpr = "34532";
            string expectedEmail = "Amypip@gmail.com";
            string expectedPhoneNumber = "42254628";
            string expectedPassword = "bwervr";
            string expectedStatusDescription = "part time. Weekends only";
      
            myController.UpdateStaffMember(48, "Amy Johnson", "34532", "42254628", "Amypip@gmail.com", "bwervr", "part time. Weekends only", 2, 2);
            myController.GetAllFromDB();

            Assert.AreEqual(expectedEmail, myController.StaffMembers[0].Email);
            Assert.AreEqual(expectedCpr, myController.StaffMembers[0].Cpr);
            Assert.AreEqual(expectedPhoneNumber, myController.StaffMembers[0].PhoneNumber);
            Assert.AreEqual(expectedPassword, myController.StaffMembers[0].Password);
            Assert.AreEqual(expectedStatusDescription, myController.StaffMembers[0].StatusDescription);
          
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
        [TestMethod]
        public void NumbersOfStaffmembersTest()
         {
            Controller myController = new Controller();
            int expected = myController.NumberOfStaffMembers();
            int actual = myController.StaffMembers.Count;
            Assert.AreEqual(expected, actual);
         }
        [TestMethod]
        public void NumbersOfMessagesTest()
        {
            Controller myController = new Controller();
            int expected = myController.NumberOfMessages();
            int actual = myController.Messages.Count;
            Assert.AreEqual(expected, actual);
        }
        //[TestMethod]
        //public void NumbersOfStaffmembersTest()
        //{
        //    Controller myController = new Controller();
        //    int expected = myController.NumberOfStaffMembers();
        //    int actual = myController.StaffMembers.Count;
        //    Assert.AreEqual(expected, actual);
        //}
        [TestMethod]
        public void NumbersOfShiftDatesTest()
        {
            Controller myController = new Controller();
            int expected = myController.NumberOfShiftDate();
            int actual = myController.ShiftDates.Count;
            Assert.AreEqual(expected, actual);
        }
        
    }
}
