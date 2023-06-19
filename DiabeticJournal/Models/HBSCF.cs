using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticJournal.Models
{
    [Table("HBSCFS")]
    public class HBSCF
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int CorrectionFactor { get; set; }
    }
}
