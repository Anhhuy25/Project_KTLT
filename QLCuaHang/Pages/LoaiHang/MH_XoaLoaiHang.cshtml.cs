using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLCuaHang.Business;
using QLCuaHang.Entity;

namespace QLCuaHang.Pages.LoaiHang
{
    public class MH_XoaLoaiHangModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string PiD { get; set; }
        public LoaiHangSP lh;
        public void OnGet()
        {
            lh = XL_LoaiHang.docLoaiHang(PiD);
        }

        public void OnPost()
        {
            lh = XL_LoaiHang.docLoaiHang(PiD);
            XL_LoaiHang.xoaLoaiHang(lh);
            Response.Redirect("/MH_LoaiHang");
        }
    }
}
