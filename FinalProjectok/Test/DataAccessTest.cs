using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ControllerLayer;
using ModelLayer;
using InterfaceLayer;

namespace Test
{
    /// <summary>
    /// Summary description for DataAccessTest
    /// </summary>
    [TestClass]
    public class DataAccessTest         //Sebastian and majd
    {
          [TestMethod]
        public void ConnectToDb()
        {
             DataAccessDB myDb = new DataAccessDB();
            
              Assert.IsTrue(myDb.ConnectToDB());
        }
    }
}
