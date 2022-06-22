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
    public partial class DetailForm : Form
    {
        public delegate void MyDel(int maMonAn,string name);
        public MyDel d { get; set; }
        public string MaNL { get; set; }
        public MonAnNguyenLieu sp { get; set; }
        public DetailForm(string maNL)
        {
            InitializeComponent();
            if (maNL == "" || MaNL == null)
            {
                sp = QLNHBLL.Instance.GetNguyenLieuByMaNL(maNL);
            }
            else
            {
                sp = new MonAnNguyenLieu();
            }

            MaNL = maNL;

            foreach (MonAnNguyenLieu i in QLNL.Instance.MonAnNguyenLieus.ToList())
            {
                cbbDonViTinh.Items.Add(i.DonViTinh);
            }
            LoadData();
            GUI();
        }
        public void GUI()
        {
            if (MaNL != "")
            {
                cbbDonViTinh.Text = sp.DonViTinh;
                tfSoLuong.Text = sp.SoLuong.ToString();
                cbbTenNguyenLieu.Text = sp.NguyenLieu.TenNL;
                if (sp.NguyenLieu.TinhTrang)
                {
                    cbbTinhTrang.SelectedIndex = 0;
                }
                else
                {
                    cbbTinhTrang.SelectedIndex = 1;
                }
            }
        }
        public void LoadData()
        {
            foreach (NguyenLieu nguyenLieu in QLNL.Instance.NguyenLieus.ToList())
            {
                cbbTenNguyenLieu.Items.Add(nguyenLieu.TenNL);
            }
            foreach (MonAnNguyenLieu item in QLNL.Instance.MonAnNguyenLieus.ToList())
            {
                if (!cbbDonViTinh.Items.Contains(item.DonViTinh))
                    cbbDonViTinh.Items.Add(item.DonViTinh);
            }
            cbbTinhTrang.Items.Add(new CBBTinhTrang { value = true });
            cbbTinhTrang.Items.Add(new CBBTinhTrang { value = false });
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            QLNHBLL.Instance.AddUpdate(GetSP());
            d(0, "");
            this.Close();
        }

        private void btCc_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private MonAnNguyenLieu GetSP()
        {
            sp.DonViTinh = cbbDonViTinh.SelectedItem.ToString();
            sp.NguyenLieu = QLNHBLL.Instance.GetNLByName(cbbTenNguyenLieu.SelectedItem.ToString());
            sp.NguyenLieu.TinhTrang = ((CBBTinhTrang)cbbTinhTrang.SelectedItem).value;
            //if (Int32.TryParse(tfSoLuong.Text, out int k))
            //{
            //    sp.SoLuong = k;
            //}
            sp.SoLuong = Convert.ToInt32(tfSoLuong.Text);
            return sp;
        }
    }
}
