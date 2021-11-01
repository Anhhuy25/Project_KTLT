using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLCuaHang.Entity;
using QLCuaHang.Business;

namespace QLCuaHang.Pages
{
    public class MH_MatHangModel : PageModel
    {
        public SanPham[] dsSanPham;
        [BindProperty]
        public string MaHang { get; set; }
        
        public void OnGet()
        {
            dsSanPham = XL_SanPham.timSanPham();
        }

        public void OnPost()
        {
            dsSanPham = XL_SanPham.timSanPham(MaHang);
        }

        
    }
}
