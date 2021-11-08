using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QLCuaHang.Entity;

namespace QLCuaHang.DAL
{
    public class LT_HoaDonBan
    {
        public static HoaDonMH[] docDSHoaDonBan()
        {
            StreamReader file = new StreamReader(@"C:\Users\Admin\Desktop\VB2\HK1 2021-2022\Kĩ thuật lập trình\20880241\hoadonban.json");
            string json = file.ReadToEnd();
            HoaDonMH[] kq = JsonConvert.DeserializeObject<HoaDonMH[]>(json);

            file.Close();
            return kq;
        }

        public static void luuDSHoaDonBan(HoaDonMH[] hd)
        {
            StreamWriter file = new StreamWriter(@"C:\Users\Admin\Desktop\VB2\HK1 2021-2022\Kĩ thuật lập trình\20880241\hoadonban.json");
            string json = JsonConvert.SerializeObject(hd);
            file.Write(json);
            file.Close();
        }

        public static void themHoaDonBan(HoaDonMH hd)
        {
            HoaDonMH[] dsHD = docDSHoaDonBan();

            HoaDonMH[] dsHDMoi = new HoaDonMH[dsHD.Length + 1];
            for (int i = 0; i < dsHD.Length; i++)
            {
                dsHDMoi[i] = dsHD[i];
            }
            dsHDMoi[dsHDMoi.Length - 1] = hd;

            luuDSHoaDonBan(dsHDMoi);
        }

        public static HoaDonMH docHoaDonBan(string id)
        {
            HoaDonMH[] ds = docDSHoaDonBan();
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].maHD == id)
                {
                    return ds[i];
                }
            }
            return new HoaDonMH();
        }

        public static void suaHoaDonBan(HoaDonMH hd)
        {
            HoaDonMH[] ds = docDSHoaDonBan();
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].maHD == hd.maHD)
                {
                    ds[i] = hd;
                }
            }
            luuDSHoaDonBan(ds);
        }

        public static void xoaHoaDonBan(HoaDonMH hd)
        {
            HoaDonMH[] ds = docDSHoaDonBan();
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
            luuDSHoaDonBan(dsHDMoi);

        }
    }
}
