using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concerts.DbModels
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        public string NameOfEvent { get; set; }

        public DateTime DateOfEvent { get; set; }

        public string DescriptionOfEvent { get; set; }

        public string CategoryOfEvent { get; set; }

        public TimeSpan Time { get; set; }

        public string ParticipantsJson { get; set; }
    }
}
