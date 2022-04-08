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
        private RecordsManager _manager;
        IEnumerable<Record> noFilterList;
        IEnumerable<Record> recordList;

        [TestInitialize]
        public void init()
        {
            _manager = new RecordsManager();
            noFilterList = _manager.GetAll("","");
            recordList = _manager.GetAll("", "");
        }


        [TestMethod()]
        public void GetAllTest()
        {
            //Arrange
            string artist = "kid";
            string year = "2011";

            //Act
            recordList = _manager.GetAll(artist, year);

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

        [TestMethod()]
        public void PostMethodTest()
        {
            //Arrange
            Record newRecord = new Record("bjørnebjørn er en bjørn", "Sigurd", 14500, "2002");

            //Act
            _manager.AddRecord(newRecord);
            recordList = _manager.GetAll("","");

            //Assert
            Assert.AreEqual(4, recordList.ElementAt(3).Id);
            Assert.AreEqual("Sigurd", recordList.ElementAt(3).Artist);
        }

        [TestMethod]
        //public void DeleteMethodTest()
        //{
        //    //Arrange
        //    Record Record = new Record("Hells angels", "Slipknot", 11501, "2008");

        //    _manager.AddRecord(Record);
        //    recordList = _manager.GetAll("", "");

        //    //Act
        //    Assert.AreEqual(4, recordList.Count());
        //    _manager.DeleteRecord(4);
        //    _manager.GetAll("","");

        //    //Assert
            
        //    Assert.AreEqual(3, recordList.Count());
        //}
    }
}