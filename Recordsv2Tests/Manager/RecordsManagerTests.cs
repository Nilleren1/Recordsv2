using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recordsv2.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recordsv2.Models;

namespace Recordsv2.Manager.Tests
{
    [TestClass()]
    public class RecordsManagerTests
    {

        RecordsManager _manager = new RecordsManager();

        [TestMethod()]
        public void GetAllTest()
        {
            //Arrange
            IEnumerable<Record> recordList;


            //Act
            recordList = _manager.GetAll();

            //Assert
            //Vi gør det på to måder for at vise de forskellige måder det kan gøres på.
            Assert.IsNotNull(_manager.GetAll());
            Assert.IsNotNull(recordList);

        }
    }
}