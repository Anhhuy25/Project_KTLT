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
    public class MH_ThemSanPhamModel : PageModel
    {
        [BindProperty]
        public string MaHang { get; set; }
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
        public string Error { get; set; }

        public LoaiHangSP[] dsLH;
        public void OnGet()
        {
            dsLH = XL_LoaiHang.timLoaiHang();
        }

        public void OnPost()
        {

            SanPham spMoi = new SanPham();
            dsLH = XL_LoaiHang.timLoaiHang();
            spMoi.maMH = MaHang;
            spMoi.tenMH = TenHang;
            spMoi.loaiMH = LoaiHang;
            spMoi.congtySX = CongTy;
            spMoi.ngaySX = NgaySanXuat;
            spMoi.hanSD = HanSuDung;
            XL_SanPham.luuSanPham(spMoi);
            Response.Redirect("/MH_MatHang");
            /*if (XL_SanPham.error(spMoi) == "")
            {
                XL_SanPham.luuSanPham(spMoi);
                Response.Redirect("/MH_MatHang");
            }
            else
            {
                Error = XL_SanPham.error(spMoi);
            }*/
        }
    }
}
