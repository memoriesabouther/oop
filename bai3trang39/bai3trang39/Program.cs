// Interface IHienThi
interface IHienThi
{
    void Xuat();
}

// Lớp hàng hóa
class HangHoa : IHienThi
{
    protected string maHang;
    protected string tenHang;

    // Phương thức khởi tạo mặc định
    public HangHoa()
    {
        this.maHang = "";
        this.tenHang = "";
    }

    // Phương thức khởi tạo có tham số
    public HangHoa(string maHang, string tenHang)
    {
        if (maHang.Length == 5 && maHang.Substring(0, 2) == "HH" && int.TryParse(maHang.Substring(2), out _))
        {
            this.maHang = maHang;
        }
        else
        {
            this.maHang = "HH001";
        }
        this.tenHang = tenHang;
    }

    // Triển khai phương thức Xuat() từ interface IHienThi
    public void Xuat()
    {
        Console.WriteLine("Mã hàng: " + maHang);
        Console.WriteLine("Tên hàng: " + tenHang);
    }
}

// Lớp Nước giải khát kế thừa từ lớp hàng hóa
class NuocGiaiKhat : HangHoa
{
    private string donViTinh;
    private int soLuong;
    private double donGia;
    private double tiLeChietKhau;

    // Phương thức khởi tạo có tham số
    public NuocGiaiKhat(string maHang, string tenHang, string donViTinh, int soLuong, double donGia)
        : base(maHang, tenHang)
    {
        if (donViTinh == "kết" || donViTinh == "thùng" || donViTinh == "chai" || donViTinh == "lon")
        {
            this.donViTinh = donViTinh;
        }
        else
        {
            this.donViTinh = "kết";
        }
        this.soLuong = soLuong;
        this.donGia = donGia;
        this.tiLeChietKhau = 0.9; // Tỉ lệ chiết khấu mặc định
    }

    // Triển khai phương thức Xuat() từ interface IHienThi
    public new void Xuat()
    {
        base.Xuat();
        Console.WriteLine("Đơn vị tính: " + donViTinh);
        Console.WriteLine("Số lượng: " + soLuong);
        Console.WriteLine("Đơn giá: " + donGia);
        Console.WriteLine("Tổng tiền: " + TinhTongTien());
    }

    // Phương thức tính tổng tiền
    private double TinhTongTien()
    {
        double thanhTien;
        if (donViTinh == "kết" || donViTinh == "thùng")
        {
            thanhTien = soLuong * donGia;
        }
        else if (donViTinh == "chai")
        {
            thanhTien = soLuong * donGia / 20;
        }
        else // donViTinh == "lon"
        {
            thanhTien = soLuong * donGia / 24;
        }
        return thanhTien * tiLeChietKhau;
    }
}

// Lớp chương trình chính
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Nhập thông tin hàng hóa:");

        Console.Write("Mã hàng: ");
        string maHang = Console.ReadLine();

        Console.Write("Tên hàng: ");
        string tenHang = Console.ReadLine();

        Console.Write("Đơn vị tính: ");
        string donViTinh = Console.ReadLine();

        Console.Write("Số lượng: ");
        int soLuong = int.Parse(Console.ReadLine());

        Console.Write("Đơn giá: ");
        double donGia = double.Parse(Console.ReadLine());

        NuocGiaiKhat nuocGiaiKhat = new NuocGiaiKhat(maHang, tenHang, donViTinh, soLuong, donGia);

        Console.WriteLine("\nThông tin hàng hóa:");
        nuocGiaiKhat.Xuat();

        Console.ReadKey();
    }
}

