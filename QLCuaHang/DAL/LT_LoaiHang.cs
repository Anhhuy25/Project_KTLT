using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QLCuaHang.Entity;

namespace QLCuaHang.DAL
{
    public class LT_LoaiHang
    {
        public static LoaiHangSP[] docDSLoaiHang()
        {
            StreamReader file = new StreamReader(@"C:\Users\Admin\Desktop\VB2\HK1 2021-2022\Kĩ thuật lập trình\20880241\loaihang.json");
            string json = file.ReadToEnd();
            LoaiHangSP[] kq = JsonConvert.DeserializeObject<LoaiHangSP[]>(json);

            file.Close();
            return kq;
        }

        public static void luuDSLoaiHang(LoaiHangSP[] lh)
        {
            StreamWriter file = new StreamWriter(@"C:\Users\Admin\Desktop\VB2\HK1 2021-2022\Kĩ thuật lập trình\20880241\loaihang.json");
            string json = JsonConvert.SerializeObject(lh);
            file.Write(json);
            file.Close();
        }

        public static void themLoaiHang(LoaiHangSP lh)
        {
            LoaiHangSP[] dsLH = docDSLoaiHang();

            LoaiHangSP[] dsLHMoi = new LoaiHangSP[dsLH.Length + 1];
            for (int i = 0; i < dsLH.Length; i++)
            {
                dsLHMoi[i] = dsLH[i];
            }
            dsLHMoi[dsLHMoi.Length - 1] = lh;

            luuDSLoaiHang(dsLHMoi);
        }

        public static LoaiHangSP docLoaiHang(string id)
        {
            LoaiHangSP[] ds = docDSLoaiHang();
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].maLH == id)
                {
                    return ds[i];
                }
            }
            return new LoaiHangSP();
        }

        public static void suaLoaiHang(LoaiHangSP lh)
        {
            LoaiHangSP[] ds = docDSLoaiHang();
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].maLH == lh.maLH)
                {
                    ds[i] = lh;
                }
            }
            luuDSLoaiHang(ds);
        }

        public static void xoaLoaiHang(LoaiHangSP lh)
        {
            LoaiHangSP[] ds = docDSLoaiHang();
            LoaiHangSP[] dsLHMoi = new LoaiHangSP[ds.Length - 1];
            int j = 0;
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].maLH != lh.maLH)
                {
                    dsLHMoi[j] = ds[i];
                    j++;
                }
            }
            luuDSLoaiHang(dsLHMoi);

        }
    }
}
