using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using QLCuaHang.Entity;
using Newtonsoft.Json;

namespace QLCuaHang.DAL
{
    public class LT_HoaDonNhap
    {
        public static HoaDonMH[] docDSHoaDonNhap()
        {
            StreamReader file = new StreamReader(@"C:\Users\Admin\Desktop\VB2\HK1 2021-2022\Kĩ thuật lập trình\20880241\hoadonnhap.json");
            string json = file.ReadToEnd();
            HoaDonMH[] kq = JsonConvert.DeserializeObject<HoaDonMH[]>(json);

            file.Close();
            return kq;
        }

        public static void luuDSHoaDonNhap(HoaDonMH[] hd)
        {
            StreamWriter file = new StreamWriter(@"C:\Users\Admin\Desktop\VB2\HK1 2021-2022\Kĩ thuật lập trình\20880241\hoadonnhap.json");
            string json = JsonConvert.SerializeObject(hd);
            file.Write(json);
            file.Close();
        }

        public static void themHoaDonNhap(HoaDonMH hd)
        {
            HoaDonMH[] dsHD = docDSHoaDonNhap();

            HoaDonMH[] dsHDMoi = new HoaDonMH[dsHD.Length + 1];
            for (int i = 0; i < dsHD.Length; i++)
            {
                dsHDMoi[i] = dsHD[i];
            }
            dsHDMoi[dsHDMoi.Length - 1] = hd;

            luuDSHoaDonNhap(dsHDMoi);
        }

        public static HoaDonMH docHoaDonNhap(string id)
        {
            HoaDonMH[] ds = docDSHoaDonNhap();
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].maHD == id)
                {
                    return ds[i];
                }
            }
            return new HoaDonMH();
        }

        public static void suaHoaDonNhap(HoaDonMH hd)
        {
            HoaDonMH[] ds = docDSHoaDonNhap();
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].maHD == hd.maHD)
                {
                    ds[i] = hd;
                }
            }
            luuDSHoaDonNhap(ds);
        }

        public static void xoaHoaDonNhap(HoaDonMH hd)
        {
            HoaDonMH[] ds = docDSHoaDonNhap();
            HoaDonMH[] dsHDMoi = new HoaDonMH[ds.Length - 1];
            int j = 0;
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].maHD != hd.maHD)
                {
                    dsHDMoi[j] = ds[i];
                    j++;
                }
            }
            luuDSHoaDonNhap(dsHDMoi);

        }
    }
}
