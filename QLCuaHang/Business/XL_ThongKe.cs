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
            SanPham[] ds = LT_SanPham.docDSSanPham();
            SanPham[] kq;
            int n = 0;
            DateTime now = DateTime.Now;
            for (int i = 0; i < ds.Length; i++)
            {
                int compare = DateTime.Compare(ds[i].hanSD, now);
                if (compare < 0)
                {
                    n++;
                }
            }
            kq = new SanPham[n];
            int j = 0;
            for (int i = 0; i < ds.Length; i++)
            {
                int compare = DateTime.Compare(ds[i].hanSD, now);
                if (compare < 0)
                {
                    kq[j] = ds[i];
                    j++;
                }
            }
            return kq;
        }

        public static int tkSoLuongHangConLai(LoaiHangSP[] ds, SanPham sp)
        {
            SanPham[] dsSP = LT_SanPham.docDSSanPham();
            DateTime d = DateTime.Now;
            int n = 0;
            for (int i = 0; i < ds.Length; i++)
            {
                for (int j = 0; j < dsSP.Length; j++)
                {
                    // So sánh hạn sd của sp với ngày hiện tại
                    int compare = DateTime.Compare(dsSP[j].hanSD, d);
                    if (ds[i].tenLH == dsSP[j].loaiMH && compare > 0 && ds[i].tenLH == sp.loaiMH)
                    {
                        n++;
                    }
                }
            }
            return n;
        }

        public static SanPham[] TKHangConLai(LoaiHangSP[] dsLH, SanPham sp)
        {
            SanPham[] dsSP = LT_SanPham.docDSSanPham();
            int n = tkSoLuongHangConLai(dsLH, sp);
            DateTime d = DateTime.Now;
            int j = 0;
            SanPham[] dsSPConLai = new SanPham[n];
            for (int i = 0; i < dsSP.Length; i++)
            {
                // So sánh hạn sd của sp với ngày hiện tại
                int compare = DateTime.Compare(dsSP[i].hanSD, d);
                if (compare > 0 && dsSP[i].loaiMH == sp.loaiMH)
                {
                    dsSPConLai[j] = dsSP[i];
                    j++;
                }

            }
            return dsSPConLai;
        }
    }
}
