using System;
using System.Collections.Generic;

namespace DAO.Models
{
    public partial class Language
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Country { get; set; } = null!;
    }
}
