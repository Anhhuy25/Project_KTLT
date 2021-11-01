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
    public class MH_LoaiHangModel : PageModel
    {
        public LoaiHangSP[] dsLoaiHang;
        [BindProperty]
        public string MaLoaiHang { get; set; }
        public void OnGet()
        {
            dsLoaiHang = XL_LoaiHang.timLoaiHang();
        }

        public void OnPost()
        {
            dsLoaiHang = XL_LoaiHang.timLoaiHang(MaLoaiHang);
        }
    }
}
