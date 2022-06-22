using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestThuQLNH.DTO
{
    public class CBBTinhTrang
    {
        public bool value { get; set; }
        public override string ToString()
        {
            if (value)
            {
                return "đã nhập hàng";
            }
            return "chưa nhập hàng";
        }
    }
}
