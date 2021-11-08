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
    public class MH_SuaHoaDonNhapModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string PiD { get; set; }
        [BindProperty]
        public DateTime ngayTaoHD { get; set; }
        public string error { get; set; }
        public void OnGet()
        {
            HoaDonMH hd = XL_HoaDonNhap.docHoaDonNhap(PiD);
            if (hd.maHD != "")
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
            HoaDonMH hd = XL_HoaDonNhap.docHoaDonNhap(PiD);
            hd.ngayTaoHD = ngayTaoHD;
            XL_HoaDonNhap.suaHoaDonNhap(hd);
            Response.Redirect("./MH_HoaDonNhap");
        }
    }
}
