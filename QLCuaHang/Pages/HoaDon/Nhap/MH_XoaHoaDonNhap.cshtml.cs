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
    public class MH_XoaHoaDonNhapModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string PiD { get; set; }
        public HoaDonMH h;
        public void OnGet()
        {
            h = XL_HoaDonNhap.docHoaDonNhap(PiD);
        }

        public void OnPost()
        {
            h = XL_HoaDonNhap.docHoaDonNhap(PiD);
            XL_HoaDonNhap.xoaHoaDonNhap(h);
            Response.Redirect("./MH_HoaDonNhap");
        }
    }
}
