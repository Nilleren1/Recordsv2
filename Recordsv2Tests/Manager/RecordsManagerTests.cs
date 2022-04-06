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
            IEnumerable<Record> noFilterList;
            IEnumerable<Record> recordList;
            string artist = "kid";
            string year = "2011";

            //Act
            recordList = _manager.GetAll(artist, year);
            noFilterList = _manager.GetAll("", "");

            //Assert
            //Vi gør det på to måder for at vise de forskellige måder det kan gøres på.
            Assert.IsNotNull(_manager.GetAll(artist, year));
            Assert.IsNotNull(recordList);
            Assert.IsNotNull(noFilterList);

            Assert.AreEqual("Kidd", recordList.ElementAt(0).Artist);
            Assert.AreEqual("2011", recordList.ElementAt(0).PublicationYear);
            Assert.AreEqual(3, noFilterList.Count());
            Assert.AreEqual("Elvis best Beats", noFilterList.ElementAt(0).Title);
            
        }
    }
}