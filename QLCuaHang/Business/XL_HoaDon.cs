using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QLCuaHang.Entity;
using QLCuaHang.DAL;

namespace QLCuaHang.Business
{
    public class XL_HoaDon
    {
        public static HoaDonMH[] timHoaDon(string id = "")
        {
            HoaDonMH[] ds = LT_HoaDon.docDSHoaDon();
            HoaDonMH[] kq;
            int n = 0;
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].maHD.Contains(id))
                {
                    n++;
                }
            }
            kq = new HoaDonMH[n];
            int j = 0;
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].maHD.Contains(id))
                {
                    kq[j] = ds[i];
                    j++;
                }
            }

            return kq;
        }

        public static void luuHoaDon(HoaDonMH hd)
        {
            LT_HoaDon.themHoaDon(hd);
        }

        public static HoaDonMH docHoaDon(string id)
        {
            HoaDonMH hd = LT_HoaDon.docHoaDon(id);
            return hd;
        }

        public static void suaHoaDon(HoaDonMH hd)
        {
            LT_HoaDon.suaHoaDon(hd);
        }

        public static void xoaHoaDon(HoaDonMH hd)
        {
            LT_HoaDon.xoaHoaDon(hd);
        }
    }
}
