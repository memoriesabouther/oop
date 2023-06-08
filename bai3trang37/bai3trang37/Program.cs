using System;

class HangHoa
{
    protected string maHang;
    protected string tenHang;

    public HangHoa()
    {
        maHang = "";
        tenHang = "";
    }

    public HangHoa(string maHang, string tenHang)
    {
        if (KiemTraMaHang(maHang))
            this.maHang = maHang;
        else
            this.maHang = "HH001";

        this.tenHang = tenHang;
    }

    public void Xuat()
    {
        Console.WriteLine("Mã hàng: " + maHang);
        Console.WriteLine("Tên hàng: " + tenHang);
    }

    private bool KiemTraMaHang(string maHang)
    {
        if (maHang.Length != 5)
            return false;

        if (maHang.Substring(0, 2) != "HH")
            return false;

        if (!int.TryParse(maHang.Substring(2), out int so))
            return false;

        return true;
    }
}

class NuocGiaiKhat : HangHoa
{
    private string donViTinh;
    private int soLuong;
    private double donGia;
    private double tiLeChietKhau;

    public NuocGiaiKhat(string maHang, string tenHang, string donViTinh, int soLuong, double donGia, double tiLeChietKhau)
        : base(maHang, tenHang)
    {
        if (KiemTraDonViTinh(donViTinh))
            this.donViTinh = donViTinh;
        else
            this.donViTinh = "kết";

        this.soLuong = soLuong;
        this.donGia = donGia;
        this.tiLeChietKhau = tiLeChietKhau;
    }

    public new void Xuat()
    {
        base.Xuat();
        Console.WriteLine("Đơn vị tính: " + donViTinh);
        Console.WriteLine("Số lượng: " + soLuong);
        Console.WriteLine("Đơn giá: " + donGia);
    }

    public double TinhTongTien()
    {
        double thanhTien;
        if (donViTinh == "kết" || donViTinh == "thùng")
            thanhTien = soLuong * donGia;
        else if (donViTinh == "chai")
            thanhTien = soLuong * donGia / 20;
        else if (donViTinh == "lon")
            thanhTien = soLuong * donGia / 24;
        else
            thanhTien = 0;

        return thanhTien * tiLeChietKhau;
    }

    private bool KiemTraDonViTinh(string donViTinh)
    {
        string[] danhSachDonViTinh = { "kết", "thùng", "chai", "lon" };
        return Array.IndexOf(danhSachDonViTinh, donViTinh) != -1;
    }
}

class Program
{
    static void Main(string[] args)
    {
        HangHoa hangHoa1 = new HangHoa();
        hangHoa1.Xuat();

        HangHoa hangHoa2 = new HangHoa("HH123", "Hàng hóa 2");
        hangHoa2.Xuat();

        NuocGiaiKhat nuocGiaiKhat1 = new NuocGiaiKhat("HH456", "Nước giải khát 1", "thùng", 10, 100000, 0.9);
        nuocGiaiKhat1.Xuat();
        double tongTien1 = nuocGiaiKhat1.TinhTongTien();
        Console.WriteLine("Tổng tiền: " + tongTien1);

        NuocGiaiKhat nuocGiaiKhat2 = new NuocGiaiKhat("HH789", "Nước giải khát 2", "chai", 20, 50000, 0.8);
        nuocGiaiKhat2.Xuat();
        double tongTien2 = nuocGiaiKhat2.TinhTongTien();
        Console.WriteLine("Tổng tiền: " + tongTien2);

        Console.ReadLine();
    }
}
