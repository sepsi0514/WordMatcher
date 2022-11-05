using System;
using System.Collections.Generic;

namespace DAO.Models
{
    public partial class VerbConjugation
    {
        public int Id { get; set; }
        public int WordId { get; set; }
        public string? Mode { get; set; }
        public string? E1 { get; set; }
        public string? E2 { get; set; }
        public string? E3 { get; set; }
        public string? T1 { get; set; }
        public string? T2 { get; set; }
        public string? T3 { get; set; }
    }
}
