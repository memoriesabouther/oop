using System;
using System.Collections.Generic;
using System.Xml;

abstract class BatDongSan
{
    protected string maSo;
    protected double chieuDai;
    protected double chieuRong;

    public BatDongSan(string maSo, double chieuDai, double chieuRong)
    {
        this.maSo = maSo;
        this.chieuDai = chieuDai;
        this.chieuRong = chieuRong;
    }

    public abstract double TinhGiaTri();
    public abstract double TinhPhiKinhDoanh();
}

class DatTrong : BatDongSan
{
    public DatTrong(string maSo, double chieuDai, double chieuRong) : base(maSo, chieuDai, chieuRong)
    {
    }

    public override double TinhGiaTri()
    {
        return chieuDai * chieuRong * 10000;
    }

    public override double TinhPhiKinhDoanh()
    {
        return 0;
    }
}

class NhaO : BatDongSan
{
    protected int soLau;

    public NhaO(string maSo, double chieuDai, double chieuRong, int soLau) : base(maSo, chieuDai, chieuRong)
    {
        this.soLau = soLau;
    }

    public override double TinhGiaTri()
    {
        return chieuDai * chieuRong * 10000 + soLau * 100000;
    }

    public override double TinhPhiKinhDoanh()
    {
        return 0;
    }
}

class BietThu : BatDongSan
{
    public BietThu(string maSo, double chieuDai, double chieuRong) : base(maSo, chieuDai, chieuRong)
    {
    }

    public override double TinhGiaTri()
    {
        return chieuDai * chieuRong * 400000;
    }

    public override double TinhPhiKinhDoanh()
    {
        return chieuDai * 1000;
    }
}

class KhachSan : BatDongSan
{
    protected int soSao;

    public KhachSan(string maSo, double chieuDai, double chieuRong, int soSao) : base(maSo, chieuDai, chieuRong)
    {
        this.soSao = soSao;
    }

    public override double TinhGiaTri()
    {
        return 100000 + soSao * 50000;
    }

    public override double TinhPhiKinhDoanh()
    {
        return chieuRong * 5000;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<BatDongSan> danhSachBDS = new List<BatDongSan>();

        // Đọc thông tin bất động sản từ file XML
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("danh_sach_bds.xml");

        XmlNodeList bdsNodes = xmlDoc.SelectNodes("//BDS");
        foreach (XmlNode bdsNode in bdsNodes)
        {
            string loai = bdsNode.SelectSingleNode("Loai").InnerText;
            string maSo = bdsNode.SelectSingleNode("Ma").InnerText;
            double chieuDai = double.Parse(bdsNode.SelectSingleNode("Dai").InnerText);
            double chieuRong = double.Parse(bdsNode.SelectSingleNode("Rong").InnerText);

            BatDongSan bds;
            switch (loai)
            {
                case "DatTrong":
                    bds = new DatTrong(maSo, chieuDai, chieuRong);
                    break;
                case "NhaO":
                    int soLau = int.Parse(bdsNode.SelectSingleNode("SoLau").InnerText);
                    bds = new NhaO(maSo, chieuDai, chieuRong, soLau);
                    break;
                case "BietThu":
                    bds = new BietThu(maSo, chieuDai, chieuRong);
                    break;
                case "KhachSan":
                    int soSao = int.Parse(bdsNode.SelectSingleNode("SoSao").InnerText);
                    bds = new KhachSan(maSo, chieuDai, chieuRong, soSao);
                    break;
                default:
                    continue;
            }

            danhSachBDS.Add(bds);
        }

        // Tính tổng giá trị và phí kinh doanh của các bất động sản
        double tongGiaTri = 0;
        double tongPhiKinhDoanh = 0;
        foreach (BatDongSan bds in danhSachBDS)
        {
            tongGiaTri += bds.TinhGiaTri();
            tongPhiKinhDoanh += bds.TinhPhiKinhDoanh();
        }

        Console.WriteLine("Tổng giá trị của các bất động sản: " + tongGiaTri);
        Console.WriteLine("Tổng phí kinh doanh phải đóng: " + tongPhiKinhDoanh);

        Console.ReadLine();
    }
}
