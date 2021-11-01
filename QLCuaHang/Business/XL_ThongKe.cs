using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QLCuaHang.Entity;
using QLCuaHang.DAL;

namespace QLCuaHang.Business
{
    public class XL_ThongKe
    {
        public static SanPham[] dsSPHetHan()
        {
            SanPham[] ds = LT_ThongKe.dsSPHetHan();
            SanPham[] kq;
            int n = 0;
            DateTime now = DateTime.Now;
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].hanSD < now)
                {
                    n++;
                }
            }
            kq = new SanPham[n];
            int j = 0;
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].hanSD < now)
                {
                    kq[j] = ds[i];
                    j++;
                }
            }
            return kq;
        }
    }
}
