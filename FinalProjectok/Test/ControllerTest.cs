using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using ControllerLayer;
using ModelLayer;

using System.Diagnostics;

namespace Test
{
    [TestClass]
    public class ControllerTest
    {
       
        //[TestMethod]
        //public void DbConnection()   //????
        //{
        //    DataAccessDB myDb = new DataAccessDB();

        //}

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
    }
}
