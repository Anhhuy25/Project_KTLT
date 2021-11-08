using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLCuaHang.Entity;
using QLCuaHang.Business;

namespace QLCuaHang.Pages.HoaDon
{
    public class MH_ThemHoaDonBanModel : PageModel
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
            XL_HoaDonBan.luuHoaDonBan(hd);
            Response.Redirect("./MH_HoaDonBan");
        }
    }

}
