using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuuHoXe.Areas.CSDV.Common
{
    [Serializable]
    public class UserLogin
    {
        public string TenTK { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }

    }
}