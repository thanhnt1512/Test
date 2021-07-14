using baitap.Classes;
using baitap.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baitap
{
    public partial class Form1 : Form
    {
        private BookHandle bookHandle = null;
        public Form1()
        {
            InitializeComponent();
            bookHandle = new BookHandle();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (baitapContext data =new baitapContext())
            {
                Object[] listType = data.Categories.Select(c => c.TypeOfProduct).ToArray();
                cBtheLoai.Items.AddRange(listType);
                HienThi();
            }    
                
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            try
            {
               Book book = new Book();
               int iD = int.Parse(txtId.Text);
               string maSach = txtMaSach.Text;
               string tenSach = txtTenSach.Text;
               string tacGia = txtTacGia.Text;
               int soTrang = int.Parse(txtSoTrang.Text);
               book.Id = iD;
               book.MaSach = maSach;
               book.TenSach = tenSach;
               book.TacGia = tacGia;
               book.SoTrang = soTrang;
               bookHandle.AddDs(book);
               HienThi();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Định dạng không hợp lệ");
                return;
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
            try
            {
                int iD = int.Parse(txtId.Text);
                bookHandle.Delete(iD);
                HienThi();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            

        }
        void HienThi()
        {
            try
            {
                dgvSach.Rows.Clear();
                dgvSach.ColumnCount = 5;
                using (baitapContext data = new baitapContext())
                {
                    int i = 0;
                    foreach (Book book in data.Books.ToList())
                    {
                        dgvSach.Rows.Add();
                        dgvSach.Rows[i].Cells[0].Value = book.Id;
                        dgvSach.Rows[i].Cells[1].Value = book.MaSach;
                        dgvSach.Rows[i].Cells[2].Value = book.TenSach;
                        dgvSach.Rows[i].Cells[3].Value = book.TacGia;
                        dgvSach.Rows[i].Cells[4].Value = book.SoTrang;
                        i++;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int iD = int.Parse(txtId.Text);
                string maSach = txtMaSach.Text;
                string tenSach = txtTenSach.Text;
                string tacGia = txtTacGia.Text;
                int soTrang = int.Parse(txtSoTrang.Text);
                bookHandle.Edit(iD, maSach, tenSach, tacGia, soTrang);
                HienThi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Định dạng không hợp lệ");
                return;
            }
            
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                dgvSach.Rows.Clear();
                dgvSach.ColumnCount = 5;
                string tensach = txtTenSach.Text;
                List<Book> books = bookHandle.Search(tensach);
                int i = 0;
                foreach (Book book in books)
                {
                    dgvSach.Rows.Add();
                    dgvSach.Rows[i].Cells[0].Value = book.Id;
                    dgvSach.Rows[i].Cells[1].Value = book.MaSach;
                    dgvSach.Rows[i].Cells[2].Value = book.TenSach;
                    dgvSach.Rows[i].Cells[3].Value = book.TacGia;
                    dgvSach.Rows[i].Cells[4].Value = book.SoTrang;
                    i++;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
