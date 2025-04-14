using System;
using System.Collections.Generic;

namespace LAB2
{
    // Lớp cơ sở trừu tượng
    public abstract class Hinh
    {
        public abstract double TinhChuVi();
        public abstract double TinhDienTich();
    }

    // Hình tròn
    public class HinhTron : Hinh
    {
        public double BanKinh { get; set; }

        public HinhTron(double r)
        {
            BanKinh = r;
        }

        public override double TinhChuVi()
        {
            return 2 * Math.PI * BanKinh;
        }

        public override double TinhDienTich()
        {
            return Math.PI * BanKinh * BanKinh;
        }
    }

    // Hình vuông
    public class HinhVuong : Hinh
    {
        public double Canh { get; set; }

        public HinhVuong(double canh)
        {
            Canh = canh;
        }

        public override double TinhChuVi()
        {
            return 4 * Canh;
        }

        public override double TinhDienTich()
        {
            return Canh * Canh;
        }
    }

    // Hình chữ nhật
    public class HinhChuNhat : Hinh
    {
        public double ChieuDai { get; set; }
        public double ChieuRong { get; set; }

        public HinhChuNhat(double dai, double rong)
        {
            ChieuDai = dai;
            ChieuRong = rong;
        }

        public override double TinhChuVi()
        {
            return 2 * (ChieuDai + ChieuRong);
        }

        public override double TinhDienTich()
        {
            return ChieuDai * ChieuRong;
        }
    }

    // Hình tam giác
    public class HinhTamGiac : Hinh
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public HinhTamGiac(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public override double TinhChuVi()
        {
            return A + B + C;
        }

        public override double TinhDienTich()
        {
            double p = TinhChuVi() / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C)); // Công thức Heron
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<Hinh> danhSachHinh = new List<Hinh>();

            danhSachHinh.Add(new HinhTron(3));       // Hình tròn bán kính 3
            danhSachHinh.Add(new HinhVuong(4));      // Hình vuông cạnh 4
            danhSachHinh.Add(new HinhChuNhat(5, 7)); // Hình chữ nhật 5x7
            danhSachHinh.Add(new HinhTamGiac(3, 4, 5)); // Tam giác 3-4-5

            double tongChuVi = 0;
            double tongDienTich = 0;

            Console.WriteLine("Danh sách các hình:");
            foreach (var h in danhSachHinh)
            {
                Console.WriteLine($"- Chu vi: {h.TinhChuVi():0.00}, Diện tích: {h.TinhDienTich():0.00}");
                tongChuVi += h.TinhChuVi();
                tongDienTich += h.TinhDienTich();
            }

            Console.WriteLine("\nTổng chu vi các hình: " + tongChuVi.ToString("0.00"));
            Console.WriteLine("Tổng diện tích các hình: " + tongDienTich.ToString("0.00"));

            Console.ReadLine();
        }
    }
}

