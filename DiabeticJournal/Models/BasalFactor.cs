using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticJournal.Models
{
    [Table("BasalFactors")]
    public class BasalFactor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public double FactorRate { get; set; }
    }
}
