using System;
using System.Collections.Generic;

namespace DAO.Models
{
    public partial class Word
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public int LanguageId { get; set; }
        public string Word1 { get; set; } = null!;
        public string? Description { get; set; }
        public int? TypeId { get; set; }
    }
}
