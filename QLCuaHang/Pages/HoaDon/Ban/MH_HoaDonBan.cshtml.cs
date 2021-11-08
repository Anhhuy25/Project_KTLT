using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLCuaHang.Entity;
using QLCuaHang.Business;

namespace QLCuaHang.Pages
{
    public class MH_HoaDonBanModel : PageModel
    {
        public HoaDonMH[] dsHoaDon;

        [BindProperty]
        public string MaHD { get; set; }
        [BindProperty]
        public DateTime NgayTaoHD { get; set; }

        public void OnGet()
        {
            dsHoaDon = XL_HoaDonBan.timHoaDonBan();
        }

        public void OnPost()
        {
            dsHoaDon = XL_HoaDonBan.timHoaDonBan(MaHD, NgayTaoHD);
        }
    }
}
