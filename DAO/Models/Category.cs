using System;
using System.Collections.Generic;

namespace DAO.Models
{
    public partial class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int? ParentId { get; set; }
        public int? Class { get; set; }
    }
}
