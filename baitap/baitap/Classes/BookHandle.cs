using baitap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace baitap.Classes
{
    class BookHandle : IBookHandle
    {
        private baitapContext data = null;
        public BookHandle()
        {
            data = new baitapContext();
        }
        public void AddDs(Book book)
        {
            try
            {
                data.Books.Add(book);
                data.SaveChanges();
                MessageBox.Show("succes");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public void Delete(int id)
        {
            try
            {
                data.Books.Remove(data.Books.Find(id));
                data.SaveChanges();
                MessageBox.Show("success");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Edit(int id, string maSach, string tensach, string tacGia, int soTrang)
        {
            
            try
            {
                Book book = data.Books.Find(id);
                if (book != null)
                {
                    book.Id = id;
                    book.MaSach = maSach;
                    book.TenSach = tensach;
                    book.TacGia = tacGia;
                    book.SoTrang = soTrang;
                    data.SaveChanges();
                    MessageBox.Show("Success");
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
             
        }

        public List<Book> Search(string tensach)
        {
            List<Book> books = null;
            try
            {
                books = data.Books.Where(book => book.TenSach == tensach).ToList();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return books;
        }
    }
}
