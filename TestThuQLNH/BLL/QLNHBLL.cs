using TestThuQLNH.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestThuQLNH.BLL
{
    public class QLNHBLL
    {
        private static QLNHBLL _Instance;
        public static QLNHBLL Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new QLNHBLL();
                return _Instance;
            }
            private set { }
        }
        private QLNHBLL() { }
            public List<CBBItem> GetCBBMonAn()
            {
                List<CBBItem> data = new List<CBBItem>();
                foreach (MonAn item in QLNL.Instance.MonAns)
                {
                    data.Add(new CBBItem { Text = item.TenMonAn, Value = item.MaMonAn });
                }
                return data;
            }

        //public List<MonAnNguyenLieu> GetSPfromDGV(int maNhaCC,string name)
        //{
        //    if (maNhaCC == 0)
        //    {
        //        return QLNL.Instance.SanPhams.Where(p => p.NameSP.Contains(name)).ToList();
        //    }
        //    else
        //    {
        //        return QLNL.Instance.SanPhams.Where(p => p.MaNhaCC == maNhaCC && p.NameSP.Contains(name)).ToList();
        //    }

        //}
        public List<MonAnNguyenLieu> getBySearchbox(int MaMonAn, string TenNL)
        {
            var query = from c in QLNL.Instance.MonAnNguyenLieus where c.MonAn.TenMonAn.Contains(TenNL) select c;
            if (MaMonAn != 0)
            {
                query = from c in query where c.MaMonAn == MaMonAn select c;
            }
            return query.ToList();
        }

        public MonAnNguyenLieu GetNguyenLieuByMaNL(string maNL)
        {
            return QLNL.Instance.MonAnNguyenLieus.Where(x => x.Ma == maNL).FirstOrDefault();
        }
        public NguyenLieu GetNLByName(string TenNL)
        {
            return (from c in QLNL.Instance.NguyenLieus where c.TenNL == TenNL select c).FirstOrDefault();
        }

        public void AddUpdate(MonAnNguyenLieu sp)
        {
            if (QLNL.Instance.MonAnNguyenLieus.Find(sp.Ma) != null)
            {
                QLNL.Instance.SaveChanges();
            }
            else
            {
                QLNL.Instance.MonAnNguyenLieus.Add(sp);
                QLNL.Instance.SaveChanges();
            }
        }

        public void DeleteSP(string MaSP)
        {
            QLNL.Instance.MonAnNguyenLieus.Remove(QLNL.Instance.MonAnNguyenLieus.Find(MaSP));
            QLNL.Instance.SaveChanges();
        }
        //public bool CheckMaSP(string maSP)
        //{
        //    foreach(MonAnNguyenLieu s in QLNL.Instance.SanPhams)
        //    {
        //        if (s.MaSP == maSP) return true;
        //    }
        //    return false;
        //}
        ////internal List<SV> FindSV(string text, int value)
        ////{
        //    List<SV> l1;
        //    if (value == 0)
        //    {
        //        l1 = QLSV.Instance.SVs.Where(x => x.Name.Contains(text)).ToList();
        //    }
        //    else
        //    {
        //        l1 = QLSV.Instance.SVs.Where(x => x.Name.Contains(text) & x.ID_Lop == value).ToList();
        //    }
        //    return l1;
        //}

    }
}
