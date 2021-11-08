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
    public class MH_TKHangConLaiModel : PageModel
    {
        public LoaiHangSP[] dsLH;
        public SanPham[] dsSPConLai;
        public int soLuong;
        [BindProperty]
        public string LoaiHang { get; set; }
        public void OnGet()
        {
            SanPham spMoi = new SanPham();
            dsLH = XL_LoaiHang.timLoaiHang();
            dsSPConLai = XL_ThongKe.TKHangConLai(dsLH, spMoi);
        }

        public void OnPost()
        {
            dsLH = XL_LoaiHang.timLoaiHang();
            SanPham spMoi = new SanPham();
            spMoi.loaiMH = LoaiHang;
            dsSPConLai = XL_ThongKe.TKHangConLai(dsLH, spMoi);
            soLuong = XL_ThongKe.tkSoLuongHangConLai(dsLH, spMoi);
        }
    }
}
