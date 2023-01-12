using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticJournal.Models
{
    [Table("Ratios")]
    public class Ratio
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public double CarbRate { get; set; }
    }
}
