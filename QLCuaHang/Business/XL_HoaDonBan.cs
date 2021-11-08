using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QLCuaHang.Entity;
using QLCuaHang.DAL;

namespace QLCuaHang.Business
{
    public class XL_HoaDonBan
    {
        public static HoaDonMH[] timHoaDonBan(string id = "", DateTime day = new DateTime())
        {
            HoaDonMH[] ds = LT_HoaDonBan.docDSHoaDonBan();
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

        public static void luuHoaDonBan(HoaDonMH hd)
        {
            LT_HoaDonBan.themHoaDonBan(hd);
        }

        public static HoaDonMH docHoaDonBan(string id)
        {
            HoaDonMH hd = LT_HoaDonBan.docHoaDonBan(id);
            return hd;
        }

        public static void suaHoaDonBan(HoaDonMH hd)
        {
            LT_HoaDonBan.suaHoaDonBan(hd);
        }

        public static void xoaHoaDonBan(HoaDonMH hd)
        {
            LT_HoaDonBan.xoaHoaDonBan(hd);
        }
    }
}
