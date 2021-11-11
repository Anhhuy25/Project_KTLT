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
          
        public static void luuSanPham(SanPham sp)
        {
            LT_SanPham.themSanPham(sp);
        }

        public static string loiThemSP(SanPham sp)
        {
            SanPham[] ds = LT_SanPham.docDSSanPham();
            string err = "";
            for (int i = 0; i < ds.Length; i++)
            {
                // kiểm tra mã sản phẩm
                if (sp.maMH == ds[i].maMH)
                {
                   err = "Mã mặt hàng đã tồn tại!";
                }
            }
            // kiểm tra có trường nào bị bỏ trống
            if (sp.maMH == null || sp.loaiMH == null || sp.tenMH == null || sp.congtySX == null)
            {
                err = "Vui lòng điền đầy đủ thông tin"; 
            }
            // kiểm tra ngày sx có trước hạn sd không
            int compare = DateTime.Compare(sp.ngaySX, sp.hanSD);
            if(compare > 0)
            {
                err = "Vui lòng kiểm tra lại ngày SX và hạn SD";
            }

            return err;
        }

        public static string loiSuaSP(SanPham sp)
        {
            SanPham[] ds = LT_SanPham.docDSSanPham();
            string err = "";
            // kiểm tra có trường nào bị bỏ trống
            if (sp.maMH == null || sp.loaiMH == null || sp.tenMH == null || sp.congtySX == null)
            {
                err = "Vui lòng điền đầy đủ thông tin";
            }
            // kiểm tra ngày sx có trước hạn sd không
            int compare = DateTime.Compare(sp.ngaySX, sp.hanSD);
            if (compare > 0)
            {
                err = "Vui lòng kiểm tra lại ngày SX và hạn SD";
            }

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
