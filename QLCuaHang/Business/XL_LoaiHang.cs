using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QLCuaHang.Entity;
using QLCuaHang.DAL;

namespace QLCuaHang.Business
{
    public class XL_LoaiHang
    {
        public static LoaiHangSP[] timLoaiHang(string keyword = "")
        {
            LoaiHangSP[] ds = LT_LoaiHang.docDSLoaiHang();
            LoaiHangSP[] kq;
            int n = 0;
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].maLH.Contains(keyword))
                {
                    n++;
                }
            }
            kq = new LoaiHangSP[n];
            int j = 0;
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].maLH.Contains(keyword))
                {
                    kq[j] = ds[i];
                    j++;
                }
            }

            return kq;
        }

        public static void luuLoaiHang(LoaiHangSP lh)
        {
            LT_LoaiHang.themLoaiHang(lh);
        }

        public static string error(LoaiHangSP lh)
        {
            LoaiHangSP[] ds = LT_LoaiHang.docDSLoaiHang();
            string err = "";
            for (int i = 0; i < ds.Length; i++)
            {
                if (lh.maLH == ds[i].maLH)
                {
                    err = "Mã mặt hàng bị trùng!";
                }
            }
            if (lh.maLH == null || lh.tenLH == null)
            {
                err = "Vui lòng điền đầy đủ thông tin";
            }
            
            return err;
        }

        public static LoaiHangSP docLoaiHang(string id)
        {
            LoaiHangSP lh = LT_LoaiHang.docLoaiHang(id);
            return lh;
        }

        public static void suaLoaiHang(LoaiHangSP lh)
        {
            LT_LoaiHang.suaLoaiHang(lh);
        }

        public static void xoaLoaiHang(LoaiHangSP lh)
        {
            LT_LoaiHang.xoaLoaiHang(lh);
        }
    }
}
