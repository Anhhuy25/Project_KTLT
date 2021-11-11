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
    public class MH_ThemLoaiHangModel : PageModel
    {

        [BindProperty]
        public string MaLoaiHang { get; set; }
        [BindProperty]
        public string TenLoaiHang { get; set; }
        public string err { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            LoaiHangSP lh = new LoaiHangSP();
            lh.maLH = MaLoaiHang;
            lh.tenLH = TenLoaiHang;
            if(XL_LoaiHang.loiThemLH(lh) == "")
            {
                XL_LoaiHang.luuLoaiHang(lh);
                Response.Redirect("/MH_LoaiHang");
            } else
            {
                err = XL_LoaiHang.loiThemLH(lh);
            }
        }
    }
}
