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
        public float? Weight { get; set; } = null;
        public int? TargetSugar { get; set; } = null;

    }
}
