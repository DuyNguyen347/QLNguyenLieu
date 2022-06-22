using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestThuQLNH.BLL;
using TestThuQLNH.DTO;

namespace TestThuQLNH.View
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            showDGV(0,"");

            cbbMonAn.Items.Add(new CBBItem { Value = 0, Text = "All" });
            cbbMonAn.Items.AddRange(QLNHBLL.Instance.GetCBBMonAn().ToArray());
            cbbMonAn.SelectedIndex = 0;
            
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
        }
        public void showDGV(int maMonAn, string name = "")
        {
            if (maMonAn == 0)
            {
               dataGridView1.DataSource = QLNL.Instance.MonAnNguyenLieus.Where(p => p.NguyenLieu.TenNL.Contains(name))
                 .Select(p => new { p.Ma, p.NguyenLieu.TenNL, p.SoLuong, p.DonViTinh,p.NguyenLieu.TinhTrang }).ToList();
                
            }
            else
            {
                dataGridView1.DataSource = QLNL.Instance.MonAnNguyenLieus.Where(p => p.MonAn.MaMonAn == maMonAn && p.NguyenLieu.TenNL.Contains(name))
                    .Select(p => new { p.Ma, p.NguyenLieu.TenNL, p.SoLuong, p.DonViTinh, p.NguyenLieu.TinhTrang }).ToList();
            }

        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            DetailForm f = new DetailForm("");
            f.d = new DetailForm.MyDel(showDGV);
            f.Show();
            dataGridView1.DataSource = QLNL.Instance.MonAnNguyenLieus.ToList();

        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string MaSP = dataGridView1.SelectedRows[0].Cells["Ma"].Value.ToString();
                DetailForm f = new DetailForm(MaSP);
                f.d = new DetailForm.MyDel(showDGV);
                f.Show();
            }
            else MessageBox.Show("Vui long chon 1 san pham");
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                List<string> l = new List<string>();
                foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    l.Add(i.Cells["Ma"].Value.ToString());
                }
                foreach (string i in l)
                {
                    QLNHBLL.Instance.DeleteSP(i);
                }
            }
            showDGV(0,"");
        }

        private void btSort_Click(object sender, EventArgs e)
        {
            //var l = new List<MonAnNguyenLieu>();
            //switch (cbbSort.SelectedIndex)
            //{
            //    case 0:
            //        l = QLNHBLL.Instance.GetSPfromDGV(((CBBItem)cbbNhaCC.SelectedItem).Value,tbSearch.Text).OrderBy(x => x.GiaNhap).ToList();

            //        break;
            //    case 1:
            //        l = QLNHBLL.Instance.GetSPfromDGV(((CBBItem)cbbNhaCC.SelectedItem).Value,tbSearch.Text).OrderBy(x => x.SoLuong).ToList();
            //        break;
            //    case 2:
            //        l = QLNHBLL.Instance.GetSPfromDGV(((CBBItem)cbbNhaCC.SelectedItem).Value, tbSearch.Text).OrderBy(x => x.NgayNhap).ToList();
            //        break;
            //    case 3:
            //        l = QLNHBLL.Instance.GetSPfromDGV(((CBBItem)cbbNhaCC.SelectedItem).Value, tbSearch.Text).OrderBy(x => x.NameSP).ToList();
            //        break;
            //    default:
            //        break;
            //}
            //dataGridView1.DataSource = l.Select(p =>  new { p.MaSP, p.NameSP, p.NgayNhap, p.GiaNhap, p.SoLuong, p.NhaCC.TenNhaCC, p.NhaCC.DiaChi.TenTP }).ToList();
        }

        private void cbbTinhTP_SelectedIndexChanged(object sender, EventArgs e)
        {
            showDGV(((CBBItem)cbbMonAn.SelectedItem).Value, tbSearch.Text);
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            showDGV(((CBBItem)cbbMonAn.SelectedItem).Value, tbSearch.Text);
        }

        
    }
}
