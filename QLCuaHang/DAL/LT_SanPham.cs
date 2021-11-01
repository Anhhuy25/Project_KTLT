using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using QLCuaHang.Entity;
using Newtonsoft.Json;

namespace QLCuaHang.DAL
{
    public class LT_SanPham
    {
        public static SanPham[] docDSSanPham()
        {
            StreamReader file = new StreamReader(@"C:\Users\Admin\Desktop\VB2\HK1 2021-2022\Kĩ thuật lập trình\20880241\sanpham.json");
            string json = file.ReadToEnd();
            SanPham[] kq = JsonConvert.DeserializeObject<SanPham[]>(json);

            file.Close();
            return kq;
        }

        public static void luuDSSanPham(SanPham[] sp)
        {
            StreamWriter file = new StreamWriter(@"C:\Users\Admin\Desktop\VB2\HK1 2021-2022\Kĩ thuật lập trình\20880241\sanpham.json");
            string json = JsonConvert.SerializeObject(sp);
            file.Write(json);
            file.Close();
        }

        public static void themSanPham(SanPham sp)
        {
            SanPham[] dsSP = docDSSanPham();

            SanPham[] dsSPMoi = new SanPham[dsSP.Length + 1];
            for (int i = 0; i < dsSP.Length; i++)
            {
                dsSPMoi[i] = dsSP[i];
            }
            dsSPMoi[dsSPMoi.Length - 1] = sp;

            luuDSSanPham(dsSPMoi);
        }

        public static SanPham docSanPham(string id)
        {
            SanPham[] ds = docDSSanPham();
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].maMH == id)
                {
                    return ds[i];
                }
            }
            return new SanPham();
        }

        public static void suaSanPham(SanPham sp)
        {
            SanPham[] ds = docDSSanPham();
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].maMH == sp.maMH)
                {
                    ds[i] = sp;
                }
            }
            luuDSSanPham(ds);
        }

        public static void xoaSanPham(SanPham sp)
        {
            SanPham[] ds = docDSSanPham();
            SanPham[] dsSPMoi = new SanPham[ds.Length - 1];
            int j = 0;
            for (int i = 0; i < ds.Length; i++)
            {
                if(ds[i].maMH != sp.maMH)
                {
                    dsSPMoi[j] = ds[i];
                    j++;
                }
            }
            luuDSSanPham(dsSPMoi);

        }

        
    }
}
