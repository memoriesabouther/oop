using System;

namespace CompanyABC
{
    // Interface INhanVien
    public interface INhanVien
    {
        void NhapThongTin();
        void XuatThongTin();
        void TinhLuong();
    }

    // Lớp NhanVien
    public class NhanVien : INhanVien
    {
        // Các thuộc tính của nhân viên
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public int NamVaoLam { get; set; }
        public double HeSoLuong { get; set; }
        public int SoNgayNghi { get; set; }
        public double LuongCoBan { get; set; } = 1150;

        // Phương thức khởi tạo không tham số
        public NhanVien()
        {
        }

        // Phương thức khởi tạo 3 tham số
        public NhanVien(string maNhanVien, string tenNhanVien, double heSoLuong)
        {
            MaNhanVien = maNhanVien;
            TenNhanVien = tenNhanVien;
            HeSoLuong = heSoLuong;
            NamVaoLam = DateTime.Now.Year;
            SoNgayNghi = 0;
        }

        // Phương thức nhập thông tin nhân viên
        public void NhapThongTin()
        {
            Console.WriteLine("Nhập thông tin nhân viên");
            Console.Write("Mã nhân viên: ");
            MaNhanVien = Console.ReadLine();

            Console.Write("Tên nhân viên: ");
            TenNhanVien = Console.ReadLine();

            Console.Write("Hệ số lương: ");
            HeSoLuong = Convert.ToDouble(Console.ReadLine());

            Console.Write("Số ngày nghỉ trong tháng: ");
            SoNgayNghi = Convert.ToInt32(Console.ReadLine());
        }

        // Phương thức xuất thông tin nhân viên
        public void XuatThongTin()
        {
            Console.WriteLine("Mã nhân viên: " + MaNhanVien);
            Console.WriteLine("Tên nhân viên: " + TenNhanVien);
            Console.WriteLine("Năm vào làm: " + NamVaoLam);
            Console.WriteLine("Hệ số lương: " + HeSoLuong);
            Console.WriteLine("Số ngày nghỉ trong tháng: " + SoNgayNghi);

            TinhLuong();
        }

        // Phương thức tính lương của nhân viên
        public void TinhLuong()
        {
            double heSoThiDua;

            if (SoNgayNghi <= 1)
            {
                heSoThiDua = 1.0;
            }
            else if (SoNgayNghi <= 3)
            {
                heSoThiDua = 0.75;
            }
            else
            {
                heSoThiDua = 0.5;
            }

            double phuCapThamNien = (DateTime.Now.Year - NamVaoLam) * LuongCoBan / 100;
            double luong = LuongCoBan * HeSoLuong * heSoThiDua + phuCapThamNien;

            Console.WriteLine("Lương: " + luong);
        }
    }

    // Lớp Program
    class Program
    {
        static void Main(string[] args)
        {
            // Khởi tạo một đối tượng nhân viên
            INhanVien nhanVien = new NhanVien();

            // Nhập thông tin nhân viên từ bàn phím
            nhanVien.NhapThongTin();

            Console.WriteLine("Thông tin nhân viên:");
            Console.WriteLine("--------------------");

            // Xuất thông tin nhân viên
            nhanVien.XuatThongTin();

            Console.ReadKey();
        }
    }
}
//code bình thường
using System;

namespace CompanyABC
{
    class NhanVien
    {
        private static double luongCoBan = 1150;

        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public int NamVaoLam { get; set; }
        public double HeSoLuong { get; set; }
        public int SoNgayNghi { get; set; }

        public NhanVien()
        {
            // Phương thức khởi tạo không tham số
        }

        public NhanVien(string ma, string ten, double heSoLuong)
        {
            // Phương thức khởi tạo 3 tham số
            MaNhanVien = ma;
            TenNhanVien = ten;
            NamVaoLam = DateTime.Now.Year;
            HeSoLuong = heSoLuong;
            SoNgayNghi = 0;
        }

        public NhanVien(string ma, string ten, int namVaoLam, double heSoLuong, int soNgayNghi)
        {
            // Phương thức khởi tạo đầy đủ thông tin
            MaNhanVien = ma;
            TenNhanVien = ten;
            NamVaoLam = namVaoLam;
            HeSoLuong = heSoLuong;
            SoNgayNghi = soNgayNghi;
        }

        public double TinhPhuCapThamNien()
        {
            int soNamLamViec = DateTime.Now.Year - NamVaoLam;

            if (soNamLamViec >= 5)
            {
                double phuCapThamNien = soNamLamViec * luongCoBan / 100;
                return phuCapThamNien;
            }

            return 0;
        }

        public char XetThiDua()
        {
            if (SoNgayNghi <= 1)
            {
                return 'A';
            }
            else if (SoNgayNghi <= 3)
            {
                return 'B';
            }
            else
            {
                return 'C';
            }
        }

        public double TinhLuong()
        {
            char xepLoai = XetThiDua();
            double heSoThiDua;

            if (xepLoai == 'A')
            {
                heSoThiDua = 1.0;
            }
            else if (xepLoai == 'B')
            {
                heSoThiDua = 0.75;
            }
            else
            {
                heSoThiDua = 0.5;
            }

            double phuCapThamNien = TinhPhuCapThamNien();
            double luong = luongCoBan * HeSoLuong * heSoThiDua + phuCapThamNien;

            return luong;
        }

        public void XuatThongTin()
        {
            Console.WriteLine("Mã nhân viên: " + MaNhanVien);
            Console.WriteLine("Tên nhân viên: " + TenNhanVien);
            Console.WriteLine("Năm vào làm: " + NamVaoLam);
            Console.WriteLine("Hệ số lương: " + HeSoLuong);
            Console.WriteLine("Số ngày nghỉ: " + SoNgayNghi);
            Console.WriteLine("Lương: " + TinhLuong());
        }

        public void NhapThongTin()
        {
            Console.Write("Nhập mã nhân viên: ");
            MaNhanVien = Console.ReadLine();

            Console.Write("Nhập tên nhân viên: ");
            TenNhanVien = Console.ReadLine();

            Console.Write("Nhập năm vào làm: ");
            NamVaoLam = int.Parse(Console.ReadLine());

            Console.Write("Nhập hệ số lương: ");
            HeSoLuong = double.Parse(Console.ReadLine());

            Console.Write("Nhập số ngày nghỉ: ");
            SoNgayNghi = int.Parse(Console.ReadLine());
        }
    }
}
