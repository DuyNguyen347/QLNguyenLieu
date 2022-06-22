using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestThuQLNH
{
    public class CreateDB : CreateDatabaseIfNotExists<QLNL>
    {
        protected override void Seed(QLNL context)
        {
            // MaMon tu sinh
            context.MonAns.AddRange(new MonAn[]
            {
                new MonAn{TenMonAn =  "Suon xao chua ngot"},
                new MonAn{TenMonAn =  "Ech nuong"},
                new MonAn{TenMonAn =  "Ca chien "},
                new MonAn{TenMonAn =  "Canh chua "},
            });
            context.NguyenLieus.AddRange(new NguyenLieu[]
            {
                new NguyenLieu{TenNL = "Hat Nem", TinhTrang = true},
                new NguyenLieu{TenNL= "Mam", TinhTrang = true},
                new NguyenLieu{TenNL = "Muoi", TinhTrang = false}
            }) ;
            context.SaveChanges();
            context.MonAnNguyenLieus.AddRange(new MonAnNguyenLieu[]
            {
                new MonAnNguyenLieu{MaMonAn = 1,Ma = "001",SoLuong = 5,DonViTinh = "gram",MaNL =1},
                new MonAnNguyenLieu{MaMonAn = 2,Ma = "002",SoLuong = 4,DonViTinh = "cu",MaNL = 2},
                new MonAnNguyenLieu{MaMonAn = 3,Ma = "003",SoLuong = 4,DonViTinh = "ml",MaNL = 3},

            });
            context.SaveChanges();
        }
    }
}
