using System;
using System.Collections.Generic;
using System.Xml;

namespace RealEstateManagement
{
    class RealEstate
    {
        public string Code { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }

        public virtual double CalculateValue()
        {
            return 0;
        }
    }

    class Land : RealEstate
    {
        public override double CalculateValue()
        {
            return Length * Width * 10000;
        }
    }

    class House : RealEstate
    {
        public int Floors { get; set; }

        public override double CalculateValue()
        {
            return Length * Width * 10000 + Floors * 100000;
        }
    }

    class Villa : RealEstate, IBusiness
    {
        public override double CalculateValue()
        {
            return Length * Width * 400000;
        }

        public double CalculateBusinessFee()
        {
            return Length * 1000;
        }
    }

    class Hotel : RealEstate, IBusiness
    {
        public int Stars { get; set; }

        public override double CalculateValue()
        {
            return 100000 + Stars * 50000;
        }

        public double CalculateBusinessFee()
        {
            return Width * 5000;
        }
    }

    interface IBusiness
    {
        double CalculateBusinessFee();
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<RealEstate> realEstates = new List<RealEstate>();

            Console.Write("Nhập số lượng bất động sản: ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Nhập thông tin bất động sản thứ {i + 1}:");
                Console.Write("Loại (DatTrong, NhaO, BietThu, KhachSan): ");
                string type = Console.ReadLine();

                Console.Write("Mã: ");
                string code = Console.ReadLine();

                Console.Write("Chiều dài: ");
                double length = double.Parse(Console.ReadLine());

                Console.Write("Chiều rộng: ");
                double width = double.Parse(Console.ReadLine());

                RealEstate realEstate;

                switch (type)
                {
                    case "DatTrong":
                        realEstate = new Land { Code = code, Length = length, Width = width };
                        break;
                    case "NhaO":
                        Console.Write("Số lầu: ");
                        int floors = int.Parse(Console.ReadLine());
                        realEstate = new House { Code = code, Length = length, Width = width, Floors = floors };
                        break;
                    case "BietThu":
                        realEstate = new Villa { Code = code, Length = length, Width = width };
                        break;
                    case "KhachSan":
                        Console.Write("Số sao: ");
                        int stars = int.Parse(Console.ReadLine());
                        realEstate = new Hotel { Code = code, Length = length, Width = width, Stars = stars };
                        break;
                    default:
                        Console.WriteLine("Loại không hợp lệ!");
                        continue;
                }

                realEstates.Add(realEstate);
            }

            double totalValue = 0;
            double totalBusinessFee = 0;

            foreach (RealEstate realEstate in realEstates)
            {
                totalValue += realEstate.CalculateValue();

                if (realEstate is IBusiness businessRealEstate)
                {
                    totalBusinessFee += businessRealEstate.CalculateBusinessFee();
                }
            }

            Console.WriteLine("Tổng giá trị của các bất động sản: " + totalValue);
            Console.WriteLine("Tổng phí kinh doanh phải đóng: " + totalBusinessFee);

            Console.ReadLine();
        }
    }
}
