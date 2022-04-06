using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recordsv2.Models;

namespace Recordsv2.Manager
{
    public class RecordsManager
    {
        private static List<Record> recordsList = new List<Record>()
        {
            new Record() {Title = "Elvis best Beats", Artist = "Elvis", Duration = 3600, PublicationYear = "1956"},
            new Record() {Title = "Bamses venner", Artist = "Bamse", Duration = 1600, PublicationYear = "1996"},
            new Record() {Title = "Kidd er den bedste", Artist = "Kidd", Duration = 4600, PublicationYear = "2011"}
        };


        public IEnumerable<Record> GetAll()
        {
            List<Record> result = new List<Record>(recordsList);


            return result;
        }

    }
}
