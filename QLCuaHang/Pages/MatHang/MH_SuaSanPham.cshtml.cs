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
    public class MH_SuaSanPhamModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string PiD { get; set; }
        [BindProperty]
        public string TenHang { get; set; }
        [BindProperty]
        public string LoaiHang { get; set; }
        [BindProperty]
        public string CongTy { get; set; }
        [BindProperty]
        public DateTime NgaySanXuat { get; set; }
        [BindProperty]
        public DateTime HanSuDung { get; set; }
        public string error { get; set; }
        public void OnGet()
        {
            SanPham sp = XL_SanPham.docSanPham(PiD);
            if(sp.maMH != "")
            {
                TenHang = sp.tenMH;
                LoaiHang = sp.loaiMH;
                CongTy = sp.congtySX;
                NgaySanXuat = sp.ngaySX;
                HanSuDung = sp.hanSD;
            } else
            {
                error = "Không tìm thấy sản phẩm";
            }
        }

        public void OnPost()
        {
            SanPham sp = XL_SanPham.docSanPham(PiD);
            sp.tenMH = TenHang;
            sp.loaiMH = LoaiHang;
            sp.congtySX = CongTy;
            sp.ngaySX = NgaySanXuat;
            sp.hanSD = HanSuDung;
            XL_SanPham.suaSanPham(sp);
            Response.Redirect("/MH_MatHang");
        }
    }
}
