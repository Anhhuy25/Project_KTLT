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
    public class MH_XoaHoaDonBanModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string PiD { get; set; }
        public HoaDonMH h;
        public void OnGet()
        {
            h = XL_HoaDonBan.docHoaDonBan(PiD);
        }

        public void OnPost()
        {
            h = XL_HoaDonBan.docHoaDonBan(PiD);
            XL_HoaDonBan.xoaHoaDonBan(h);
            Response.Redirect("./MH_HoaDonBan");
        }
    }
}
