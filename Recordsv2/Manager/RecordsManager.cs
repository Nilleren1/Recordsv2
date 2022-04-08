using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recordsv2.Models;

namespace Recordsv2.Manager
{
    public class RecordsManager
    {
        private static int _nextId = 1;
        private static List<Record> recordsList = new List<Record>()
        {
            new Record() {Id = _nextId++, Title = "Elvis best Beats", Artist = "Elvis", Duration = 3600, PublicationYear = "1956"},
            new Record() {Id = _nextId++, Title = "Bamses venner", Artist = "Bamse", Duration = 1600, PublicationYear = "1996"},
            new Record() {Id = _nextId++, Title = "Kidd er den bedste", Artist = "Kidd", Duration = 4600, PublicationYear = "2011"}
        };


        public IEnumerable<Record> GetAll(string filterString, string year)
        {
            IEnumerable<Record> result = new List<Record>(recordsList);
            
            result = FilterFunction(filterString, year, result);
            
            return result;
        }

        public Record GetById(int id){
            return recordsList.Find(r => r.Id == id);
        }

        public Record AddRecord(Record newRecord)
        {
            newRecord.Id = _nextId++;
            recordsList.Add(newRecord);
            return newRecord;
        }

        public Record DeleteRecord(int id){
            Record record = GetById(id);
            if (record.Id == id){
                recordsList.Remove(record);
            }
            return record;
        }

        public Record UpdateRecord(int id, Record recordToBeUpdated){
            Record record = GetById(id);
            if (record == null){
                return null;
            }
            record.Title = recordToBeUpdated.Title;
            record.Artist = recordToBeUpdated.Artist;
            record.Duration = recordToBeUpdated.Duration;
            record.PublicationYear = recordToBeUpdated.PublicationYear;
            return recordToBeUpdated;


        }

        //For refactoring purposes, method: GetAll
        public IEnumerable<Record> FilterFunction(string filterString, string year, IEnumerable<Record> result)
        {
            if (!string.IsNullOrWhiteSpace(filterString))
            {
                
                if (year != null)
                {
                    result = result.Where(
                        r => r.Title.Contains(filterString, StringComparison.OrdinalIgnoreCase)
                             && r.PublicationYear == year ||
                             r.Artist.Contains(filterString, StringComparison.OrdinalIgnoreCase)
                             && r.PublicationYear == year);
                }
                result = result.Where(
                    r => r.Title.Contains(filterString, StringComparison.OrdinalIgnoreCase) ||
                         r.Artist.Contains(filterString, StringComparison.OrdinalIgnoreCase));
            }

            return result;
        }

    }
}
