using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLCuaHang.Entity;
using QLCuaHang.Business;

namespace QLCuaHang.Pages.LoaiHang
{
    public class MH_SuaLoaiHangModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string PiD { get; set; }
        [BindProperty]
        public string TenLoaiHang { get; set; }
        public string error { get; set; }
        public void OnGet()
        {
            LoaiHangSP lh = XL_LoaiHang.docLoaiHang(PiD);
            if (lh.maLH != "")
            {
                TenLoaiHang = lh.tenLH;
            }
            else
            {
                error = "Không tìm thấy loại hàng";
            }
        }

        public void OnPost()
        {
            LoaiHangSP lh = XL_LoaiHang.docLoaiHang(PiD);
            lh.tenLH = TenLoaiHang;
            XL_LoaiHang.suaLoaiHang(lh);
            Response.Redirect("/MH_LoaiHang");
        }
    }
}
