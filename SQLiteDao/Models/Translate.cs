using System;
using System.Collections.Generic;

namespace SQLiteDao.Models
{
    public partial class Translate
    {
        public int Id { get; set; }
        public int Word1_id { get; set; }
        public int Word2_id { get; set; }
    }
}
