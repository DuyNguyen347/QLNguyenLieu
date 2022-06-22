using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestThuQLNH
{
    public class NguyenLieu
    {
        public NguyenLieu()
        {
            
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int MaNL { get; set; }
        public string TenNL { get; set; }
        public bool TinhTrang { get; set; }
        // chỉ dùng khi đó là mối quan hệ 1 nhiều ,còn 1 1 thì ko cần dóng dưới
        public virtual ICollection<MonAnNguyenLieu> MonAnNguyenLieu { get; set; }
    }
}
