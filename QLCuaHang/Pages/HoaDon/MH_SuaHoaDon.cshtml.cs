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
    public class MH_SuaHoaDonModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string PiD { get; set; }
        [BindProperty]
        public DateTime ngayTaoHD { get; set; }
        public string error { get; set; }
        public void OnGet()
        {
            HoaDonMH hd = XL_HoaDon.docHoaDon(PiD);
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
            HoaDonMH hd = XL_HoaDon.docHoaDon(PiD);
            hd.ngayTaoHD = ngayTaoHD;
            XL_HoaDon.suaHoaDon(hd);
            Response.Redirect("/MH_HoaDon");
        }
    }
}
