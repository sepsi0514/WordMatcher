using System;
using System.Collections.Generic;

namespace DAO.Models
{
    public partial class Translate
    {
        public int Id { get; set; }
        public int Word1Id { get; set; }
        public int Word2Id { get; set; }
    }
}
