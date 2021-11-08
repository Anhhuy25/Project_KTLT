using QLCuaHang.DAL;
using QLCuaHang.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLCuaHang.Business
{
    public class XL_HoaDonNhap
    {
        public static HoaDonMH[] timHoaDonNhap(string id = "", DateTime day = new DateTime())
        {
            HoaDonMH[] ds = LT_HoaDonNhap.docDSHoaDonNhap();
            HoaDonMH[] kq;
            int n = 0;
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].maHD.Contains(id) || ds[i].ngayTaoHD == day)
                {
                    n++;
                }
            }
            kq = new HoaDonMH[n];
            int j = 0;
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].maHD.Contains(id) || ds[i].ngayTaoHD == day)
                {
                    kq[j] = ds[i];
                    j++;
                }
            }

            return kq;
        }

        public static void luuHoaDonNhap(HoaDonMH hd)
        {
            LT_HoaDonNhap.themHoaDonNhap(hd);
        }

        public static HoaDonMH docHoaDonNhap(string id)
        {
            HoaDonMH hd = LT_HoaDonNhap.docHoaDonNhap(id);
            return hd;
        }

        public static void suaHoaDonNhap(HoaDonMH hd)
        {
            LT_HoaDonNhap.suaHoaDonNhap(hd);
        }

        public static void xoaHoaDonNhap(HoaDonMH hd)
        {
            LT_HoaDonNhap.xoaHoaDonNhap(hd);
        }
    }
}
