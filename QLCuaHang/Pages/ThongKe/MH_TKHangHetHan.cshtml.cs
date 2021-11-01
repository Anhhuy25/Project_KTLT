using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLCuaHang.Entity;
using QLCuaHang.Business;

namespace QLCuaHang.Pages.ThongKe
{
    public class MH_TKHangHetHanModel : PageModel
    {
        public SanPham[] ds;
        public void OnGet()
        {
            ds = XL_ThongKe.dsSPHetHan();
        }
    }
}
