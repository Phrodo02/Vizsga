using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RealEstate
{
    public class Ad
    {
        public int Area { get; set; }
        public Category Category { get; set; }
        public DateTime CreateAt { get; set; }
        public string Description { get; set; }
        public int Floors { get; set; }
        public bool FreeOfCharge { get; set; }
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string LatLong { get; set; }
        public int Rooms { get; set; }
        public Seller Seller { get; set; }

        public Ad(string row)
        {
            string[] data = row.Split(';');
            Id = int.Parse(data[0]);
            Rooms = int.Parse(data[1]);
            LatLong = data[2];
            Floors = int.Parse(data[3]);
            Area = int.Parse(data[4]);
            Description = data[5];
            FreeOfCharge = data[6] == "1" ? true : false;
            ImageUrl = data[7];
            CreateAt = DateTime.Parse(data[8]);
            Seller = new Seller { Id = int.Parse(data[9]), Name = data[10], Phone = data[11] };
            Category = new Category { Id = int.Parse(data[12]), Name = data[13] };

        }

        public static List<Ad> LoadFromCsv(string filename)
        {
            List<Ad> list = new List<Ad>();
            File.ReadAllLines(filename).Skip(1).ToList().ForEach(row => list.Add(new Ad(row)));
            return list;
        }

        public double DistanceTo(double x, double y)
        {
            double dx = double.Parse(LatLong.Split(',')[0].Replace('.', ','));
            double dy = double.Parse(LatLong.Split(',')[1].Replace('.', ','));
            return Math.Sqrt(((x - dx) * (x - dx)) + ((y - dy) * (y - dy)));
        }
    }
}
