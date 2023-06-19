using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticJournal.Models
{
    [Table("BloodRecs")]
    public class BloodRec
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public int? Carbs { get; set; }
        public int? Sugar { get; set; }
        public int TestId { get; set; }
        public int Insulin { get; set; }
        public string? Comment { get; set; }

    }
}
