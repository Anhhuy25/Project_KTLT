using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QLCuaHang.Entity;

namespace QLCuaHang.DAL
{
    public class LT_HoaDon
    {
        public static HoaDonMH[] docDSHoaDon()
        {
            StreamReader file = new StreamReader(@"C:\Users\Admin\Desktop\VB2\HK1 2021-2022\Kĩ thuật lập trình\20880241\hoadon.json");
            string json = file.ReadToEnd();
            HoaDonMH[] kq = JsonConvert.DeserializeObject<HoaDonMH[]>(json);

            file.Close();
            return kq;
        }

        public static void luuDSHoaDon(HoaDonMH[] hd)
        {
            StreamWriter file = new StreamWriter(@"C:\Users\Admin\Desktop\VB2\HK1 2021-2022\Kĩ thuật lập trình\20880241\hoadon.json");
            string json = JsonConvert.SerializeObject(hd);
            file.Write(json);
            file.Close();
        }

        public static void themHoaDon(HoaDonMH hd)
        {
            HoaDonMH[] dsHD = docDSHoaDon();

            HoaDonMH[] dsHDMoi = new HoaDonMH[dsHD.Length + 1];
            for (int i = 0; i < dsHD.Length; i++)
            {
                dsHDMoi[i] = dsHD[i];
            }
            dsHDMoi[dsHDMoi.Length - 1] = hd;

            luuDSHoaDon(dsHDMoi);
        }

        public static HoaDonMH docHoaDon(string id)
        {
            HoaDonMH[] ds = docDSHoaDon();
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].maHD == id)
                {
                    return ds[i];
                }
            }
            return new HoaDonMH();
        }

        public static void suaHoaDon(HoaDonMH hd)
        {
            HoaDonMH[] ds = docDSHoaDon();
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].maHD == hd.maHD)
                {
                    ds[i] = hd;
                }
            }
            luuDSHoaDon(ds);
        }

        public static void xoaHoaDon(HoaDonMH hd)
        {
            HoaDonMH[] ds = docDSHoaDon();
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
            luuDSHoaDon(dsHDMoi);

        }
    }
}
