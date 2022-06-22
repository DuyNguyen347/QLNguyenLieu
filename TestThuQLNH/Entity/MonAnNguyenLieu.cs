using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestThuQLNH
{
    public class MonAnNguyenLieu
    {

        [Key]
        [Required]
        [StringLength(10)]
        public string Ma { get; set; }
        public int SoLuong { get; set; }

        public string DonViTinh { get; set; }
        public int MaMonAn { get; set; }
        [ForeignKey("MaMonAn")]
        public virtual MonAn MonAn { get; set; }
        public int MaNL { get; set; }
        [ForeignKey("MaNL")]
        public virtual NguyenLieu NguyenLieu { get; set; }

    }
}
