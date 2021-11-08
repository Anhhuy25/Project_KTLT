using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QLCuaHang.Entity;
using QLCuaHang.DAL;

namespace QLCuaHang.Business
{
    public class XL_SanPham
    {
        public static SanPham[] timSanPham(string keyword = "", string name = "")
        {
            SanPham[] ds = LT_SanPham.docDSSanPham();
            SanPham[] kq;
            int n = 0;
            for (int i = 0; i < ds.Length; i++)
            {
                if ((ds[i].maMH.Contains(keyword) && String.IsNullOrEmpty(name)) 
                    || (String.IsNullOrEmpty(keyword) && ds[i].tenMH.Contains(name)) 
                    || ds[i].maMH.Contains(keyword) && ds[i].tenMH.Contains(name))
                {
                    n++;
                }
            }
            kq = new SanPham[n];
            int j = 0;
            for (int i = 0; i < ds.Length; i++)
            {
                if ((ds[i].maMH.Contains(keyword) && String.IsNullOrEmpty(name)) 
                    || (String.IsNullOrEmpty(keyword) && ds[i].tenMH.Contains(name))
                    || ds[i].maMH.Contains(keyword) && ds[i].tenMH.Contains(name))
                {
                    kq[j] = ds[i];
                    j++;
                }
            }

            return kq;
        }

        public static SanPham[] timSanPhamTheoID(string keyword = "")
        {
            SanPham[] ds = LT_SanPham.docDSSanPham();
            SanPham[] kq;
            int n = 0;
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].maMH.Contains(keyword))
                {
                    n++;
                }
            }
            kq = new SanPham[n];
            int j = 0;
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].maMH.Contains(keyword))
                {
                    kq[j] = ds[i];
                    j++;
                }
            }

            return kq;
        }

        public static SanPham[] timSanPhamTheoTen(string name = "")
        {
            SanPham[] ds = LT_SanPham.docDSSanPham();
            SanPham[] kq;
            int n = 0;
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].maMH.Contains(name))
                {
                    n++;
                }
            }
            kq = new SanPham[n];
            int j = 0;
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].maMH.Contains(name))
                {
                    kq[j] = ds[i];
                    j++;
                }
            }

            return kq;
        }

        public static void luuSanPham(SanPham sp)
        {
            LT_SanPham.themSanPham(sp);
        }

        public static string error(SanPham sp)
        {
            SanPham[] ds = LT_SanPham.docDSSanPham();
            string err = "";
            for (int i = 0; i < ds.Length; i++)
            {
                if (sp.maMH == ds[i].maMH)
                {
                   err = "Mã mặt hàng bị trùng!";
                }
            }
            if (sp.maMH == null || sp.loaiMH == null || sp.tenMH == null || sp.congtySX == null)
            {
                err = "Vui lòng điền đầy đủ thông tin"; 
            }
            //if (sp.ngaySX.Day )
            return err;
        }

        public static SanPham docSanPham(string id)
        {
            SanPham sp = LT_SanPham.docSanPham(id);
            return sp;
        }

        public static void suaSanPham(SanPham sp)
        {
            LT_SanPham.suaSanPham(sp);
        }

        public static void xoaSanPham(SanPham sp)
        {
            LT_SanPham.xoaSanPham(sp);
        }
    }
}
