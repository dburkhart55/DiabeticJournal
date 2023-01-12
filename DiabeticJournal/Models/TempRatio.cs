using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticJournal.Models
{
    public class TempRatio
    {
        public int Id { get; set; }
        public double CarbRate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set;}
    }
}
