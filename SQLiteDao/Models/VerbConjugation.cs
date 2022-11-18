using System;
using System.Collections.Generic;

namespace SQLiteDao.Models
{
    public partial class VerbConjugation
    {
        public int Id { get; set; }
        public int Word_Id { get; set; }
        public string? Mode { get; set; }
        public string? E_1 { get; set; }
        public string? E_2 { get; set; }
        public string? E_3 { get; set; }
        public string? T_1 { get; set; }
        public string? T_2 { get; set; }
        public string? T_3 { get; set; }
    }
}
