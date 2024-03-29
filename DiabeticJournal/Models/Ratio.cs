﻿using SQLite;
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
        public int UserId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int CarbRate { get; set; }
    }
}
