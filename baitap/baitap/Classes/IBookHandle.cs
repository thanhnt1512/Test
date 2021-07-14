using baitap.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace baitap.Classes
{
    interface IBookHandle
    {
        
         void AddDs(Book b);
         void Edit(int id, string maSach, string tensach, string tacGia, int soTrang);
         void Delete(int id);
         List<Book> Search(string tensach);
    }
}
