using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recordsv2.Models
{
    public class Record
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public int Duration { get; set; }
        public string PublicationYear { get; set; }

        public Record(string title, string artist, int duration, string publicationYear)
        {
            
            Title = title;
            Artist = artist;
            Duration = duration;
            PublicationYear = publicationYear;
        }

        public Record()
        {
            
        }


        public override string ToString()
        {
            return $"title:{Title},\n Artist:{Artist},\n Duration:{Duration},\n Publication Year: {PublicationYear}";
        }
    }
}
