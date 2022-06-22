using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestThuQLNH
{
    public class MonAn
    {
        public MonAn()
        {
            MonAnNguyenLieus = new HashSet<MonAnNguyenLieu>();
        }
        [Key]
        [Required]
        // Tu dong tang
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaMonAn { get; set; }
        public string TenMonAn { get; set; }
        public virtual ICollection<MonAnNguyenLieu> MonAnNguyenLieus { get; set; }
    }
}
