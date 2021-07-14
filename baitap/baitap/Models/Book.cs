using System;
using System.Collections.Generic;

#nullable disable

namespace baitap.Models
{
    public partial class Book
    {
        public int Id { get; set; }
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public string TacGia { get; set; }
        public int? SoTrang { get; set; }
        public int? IdCategory { get; set; }

        public virtual Category IdCategoryNavigation { get; set; }
    }
}
