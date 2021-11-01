using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using QLCuaHang.Entity;
using Newtonsoft.Json;

namespace QLCuaHang.DAL
{
    public class LT_ThongKe
    {
        public static SanPham[] dsSPHetHan()
        {
            StreamReader file = new StreamReader(@"C:\Users\Admin\Desktop\VB2\HK1 2021-2022\Kĩ thuật lập trình\20880241\sanpham.json");
            string json = file.ReadToEnd();
            SanPham[] kq = JsonConvert.DeserializeObject<SanPham[]>(json);

            file.Close();
            return kq;
        }
    }
}
