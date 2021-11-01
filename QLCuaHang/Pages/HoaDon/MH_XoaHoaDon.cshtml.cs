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
    public class MH_XoaHoaDonModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string PiD { get; set; }
        public HoaDonMH h;
        public void OnGet()
        {
            h = XL_HoaDon.docHoaDon(PiD);
        }

        public void OnPost()
        {
            h = XL_HoaDon.docHoaDon(PiD);
            XL_HoaDon.xoaHoaDon(h);
            Response.Redirect("/MH_HoaDon");
        }
    }
}
