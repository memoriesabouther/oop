using System;
using System.Collections.Generic;
using System.Xml;

namespace QuanLyNhanVien
{
    class Program
    {
        static void Main(string[] args)
        {
            // Đọc dữ liệu từ file XML
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Users\\TUAN NGUYEN\\source\\repos\\buoi 4\\bai2trang53\\XMLFile1.xml");

            // Lấy danh sách công ty từ file XML
            XmlNodeList companyNodes = doc.SelectNodes("/CompanyData/*");

            // Tạo danh sách nhân viên
            List<NhanVien> nhanViens = new List<NhanVien>();

            // Đếm số nhân viên của mỗi công ty
            foreach (XmlNode companyNode in companyNodes)
            {
                string companyName = companyNode.Name;
                int employeeCount = companyNode.ChildNodes.Count;
                Console.WriteLine("Công ty {0} có {1} nhân viên.", companyName, employeeCount);
            }

            // Tổng công ty T có bao nhiêu nhân viên có "Năng lực tốt"
            int nangLucTotCount = 0;
            foreach (XmlNode companyNode in companyNodes)
            {
                foreach (XmlNode employeeNode in companyNode.ChildNodes)
                {
                    string xepLoai = employeeNode.SelectSingleNode("XepLoai").InnerText;
                    if (xepLoai == "A" || xepLoai == "B")
                    {
                        nangLucTotCount++;
                    }
                }
            }
            Console.WriteLine("Tổng công ty T có {0} nhân viên có năng lực tốt.", nangLucTotCount);

            // Xuất thông tin các nhân viên chưa được xét thi đua ở công ty BCD
            XmlNode bcdCompanyNode = doc.SelectSingleNode("/CompanyData/BCD");
            Console.WriteLine("Thông tin các nhân viên chưa được xét thi đua ở công ty BCD:");
            foreach (XmlNode employeeNode in bcdCompanyNode.ChildNodes)
            {
                string employeeID = employeeNode.SelectSingleNode("MaNhanVien").InnerText;
                string employeeName = employeeNode.SelectSingleNode("TenNhanVien").InnerText;
                Console.WriteLine("Mã nhân viên: {0}, Tên nhân viên: {1}", employeeID, employeeName);
            }

            // Xuất thông tin các nhân viên lao động tiên tiến của công ty ABC
            XmlNode abcCompanyNode = doc.SelectSingleNode("/CompanyData/ABC");
            Console.WriteLine("Thông tin các nhân viên lao động tiên tiến của công ty ABC:");
            foreach (XmlNode employeeNode in abcCompanyNode.ChildNodes)
            {
                string employeeID = employeeNode.SelectSingleNode("MaNhanVien").InnerText;
                string employeeName = employeeNode.SelectSingleNode("TenNhanVien").InnerText;
                Console.WriteLine("Mã nhân viên: {0}, Tên nhân viên: {1}", employeeID, employeeName);
            }

            Console.ReadLine();
        }
    }

    class NhanVien
    {
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        // Thêm các thuộc tính khác của nhân viên tại đây

        public NhanVien(string maNhanVien, string tenNhanVien)
        {
            MaNhanVien = maNhanVien;
            TenNhanVien = tenNhanVien;
        }
    }
}
