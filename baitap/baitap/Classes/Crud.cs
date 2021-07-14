using baitap.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace baitap.Classes
{
    interface Crud
    {
        
        public void AddDs(int id, string maSach, string tensach, string tacGia, int soTrang);
        public void Edit(int id, string maSach, string tensach, string tacGia, int soTrang);
        public void Delete(int id);
        public List<Book> Search(string tensach);
    }
}
