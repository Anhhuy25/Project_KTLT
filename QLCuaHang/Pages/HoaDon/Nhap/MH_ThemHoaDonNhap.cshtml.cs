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
    public class MH_ThemHoaDonNhapModel : PageModel
    {
        [BindProperty]
        public string MaHD { get; set; }
        [BindProperty]
        public DateTime NgayTaoHD { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            HoaDonMH hd = new HoaDonMH();
            hd.maHD = MaHD;
            hd.ngayTaoHD = NgayTaoHD;
            XL_HoaDonNhap.luuHoaDonNhap(hd);
            Response.Redirect("./MH_HoaDonNhap");
        }
    }
}
