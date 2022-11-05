using System;
using System.Collections.Generic;

namespace SQLiteDao.Models
{
    public partial class Words
    {
        public int Id { get; set; }
        public int? Category_id { get; set; }
        public int Language_id { get; set; }
        public string Word { get; set; } = null!;
        public string? Description { get; set; }
        public int? Type_id { get; set; }
    }
}
