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
        private Features features = null;
        public Form1()
        {
            InitializeComponent();
            features = new Features();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int iD;
            string maSach;
            string tenSach;
            string tacGia;
            int soTrang;
            try
            {
               iD = int.Parse(txtId.Text);
               maSach = txtMaSach.Text;
               tenSach = txtTenSach.Text;
               tacGia = txtTacGia.Text;
               soTrang = int.Parse(txtSoTrang.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Định dạng không hợp lệ");
                return;
            }
            features.AddDs(iD, maSach, tenSach, tacGia, soTrang);
            HienThi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int iD;
            try
            {
                iD = int.Parse(txtId.Text);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            features.Delete(iD);
            HienThi();

        }
        void HienThi()
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            int iD;
            string maSach;
            string tenSach;
            string tacGia;
            int soTrang;
            try
            {
                iD = int.Parse(txtId.Text);
                maSach = txtMaSach.Text;
                tenSach = txtTenSach.Text;
                tacGia = txtTacGia.Text;
                soTrang = int.Parse(txtSoTrang.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Định dạng không hợp lệ");
                return;
            }
            features.Edit(iD, maSach, tenSach, tacGia, soTrang);
            HienThi();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            dgvSach.Rows.Clear();
            dgvSach.ColumnCount = 5;
            string tensach = txtTenSach.Text;
            List<Book> books = features.Search(tensach);
            int i = 0;
            foreach(Book book in books)
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
}
