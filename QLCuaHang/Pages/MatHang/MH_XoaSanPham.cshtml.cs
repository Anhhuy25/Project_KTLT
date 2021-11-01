using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLCuaHang.Business;
using QLCuaHang.Entity;

namespace QLCuaHang.Pages
{
    public class MH_XoaSanPhamModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string PiD { get; set; }
        public SanPham p;
        public void OnGet()
        {
            p = XL_SanPham.docSanPham(PiD);
        }

        public void OnPost()
        {
            p = XL_SanPham.docSanPham(PiD);
            XL_SanPham.xoaSanPham(p);
            Response.Redirect("/MH_MatHang");
        }
    }
}
