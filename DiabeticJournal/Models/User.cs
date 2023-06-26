using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticJournal.Models
{
    [Table("Users")]
    public class User
    {
        //[PrimaryKey,AutoIncrement]
        [PrimaryKey]
        [NotNull]
        [AutoIncrement]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public double? Weight { get; set; } = null;
        public int? TargetSugar { get; set; } = null;
        public int Units { get; set; }
        public string FAInsulin { get; set; } = null;
        public string SAInsulin { get; set; } = null;
        public double? OverNightBasal   { get; set; } = null;
        public string DoctorName { get; set; } = null;
        public string DoctorEmail { get; set; } = null;
        public double? BasalFactor { get; set; } = null;
        public int? DailyRequirement { get; set; } = null;
        

    }
}
