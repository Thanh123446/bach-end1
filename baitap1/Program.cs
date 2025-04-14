using System;
using System.Collections.Generic;

namespace LAB2
{
    public class PhanSo
    {
        public int TuSo { get; set; }
        public int MauSo { get; set; }

        public PhanSo() { }

        public PhanSo(int tu, int mau)
        {
            TuSo = tu;
            MauSo = mau != 0 ? mau : 1; // Tránh chia cho 0
        }

        // Nhập phân số từ người dùng
        public void Nhap()
        {
            Console.Write("Nhập tử số: ");
            TuSo = int.Parse(Console.ReadLine());
            Console.Write("Nhập mẫu số (khác 0): ");
            do
            {
                MauSo = int.Parse(Console.ReadLine());
                if (MauSo == 0)
                    Console.Write("Mẫu số phải khác 0. Nhập lại: ");
            } while (MauSo == 0);
        }

        // In phân số
        public void Xuat()
        {
            Console.WriteLine($"{TuSo}/{MauSo}");
        }

        // Rút gọn phân số
        public void RutGon()
        {
            int ucln = UCLN(Math.Abs(TuSo), Math.Abs(MauSo));
            TuSo /= ucln;
            MauSo /= ucln;
        }

        // Cộng 2 phân số
        public static PhanSo Cong(PhanSo a, PhanSo b)
        {
            int tu = a.TuSo * b.MauSo + b.TuSo * a.MauSo;
            int mau = a.MauSo * b.MauSo;
            PhanSo kq = new PhanSo(tu, mau);
            kq.RutGon();
            return kq;
        }

        // Tìm ước chung lớn nhất
        private int UCLN(int a, int b)
        {
            while (b != 0)
            {
                int r = a % b;
                a = b;
                b = r;
            }
            return a;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<PhanSo> danhSachPhanSo = new List<PhanSo>();
            Console.Write("Nhập số lượng phân số: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Phân số thứ {i + 1}:");
                PhanSo ps = new PhanSo();
                ps.Nhap();
                danhSachPhanSo.Add(ps);
            }

            // Tính tổng các phân số
            PhanSo tong = new PhanSo(0, 1);
            foreach (PhanSo ps in danhSachPhanSo)
            {
                tong = PhanSo.Cong(tong, ps);
            }

            Console.Write("Tổng các phân số là: ");
            tong.Xuat();
            Console.ReadLine();
        }
    }
}

