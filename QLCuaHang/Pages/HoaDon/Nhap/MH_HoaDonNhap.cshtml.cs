using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLCuaHang.Business;
using QLCuaHang.Entity;

namespace QLCuaHang.Pages.HoaDon.Nhap
{
    public class MH_HoaDonNhapModel : PageModel
    {
        public HoaDonMH[] dsHoaDon;

        [BindProperty]
        public string MaHD { get; set; }
        [BindProperty]
        public DateTime NgayTaoHD { get; set; }

        public void OnGet()
        {
            dsHoaDon = XL_HoaDonNhap.timHoaDonNhap();
        }

        public void OnPost()
        {
            dsHoaDon = XL_HoaDonNhap.timHoaDonNhap(MaHD, NgayTaoHD);
        }
    }
}
