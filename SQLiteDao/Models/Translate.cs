using System;
using System.Collections.Generic;

namespace SQLiteDao.Models
{
    public partial class Translate
    {
        public int Id { get; set; }
        public int Word_1_id { get; set; }
        public int Word_2_id { get; set; }
    }
}
