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
    public class MH_SuaHoaDonBanModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string PiD { get; set; }
        [BindProperty]
        public DateTime ngayTaoHD { get; set; }
        public string error { get; set; }
        public void OnGet()
        {
            HoaDonMH hd = XL_HoaDonBan.docHoaDonBan(PiD);
            if(hd.maHD != "")
            {
                ngayTaoHD = hd.ngayTaoHD;
            }
            else
            {
                error = "Không tìm thấy sản phẩm";
            }

        }

        public void OnPost()
        {
            HoaDonMH hd = XL_HoaDonBan.docHoaDonBan(PiD);
            hd.ngayTaoHD = ngayTaoHD;
            XL_HoaDonBan.suaHoaDonBan(hd);
            Response.Redirect("./MH_HoaDonBan");
        }
    }
}
