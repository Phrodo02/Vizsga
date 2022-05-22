using System;
using System.Collections.Generic;
using System.Linq;

namespace RealEstate
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Ad> ads = Ad.LoadFromCsv("realestates.csv");

            Console.WriteLine("1. Földszinti ingatlanok átlagos alapterülete: {0:f2} m2", ads.Where(e => e.Floors == 0).Average(e => e.Area));
            var closest = ads.Where(e => e.FreeOfCharge == true).OrderBy(e => e.DistanceTo(47.4164220114023, 19.066342425796986)).First();
            Console.WriteLine("2. Mesevár óvodához légvonalban legközelebb tehermentes ingatlan adatai");
            Console.WriteLine("\tEladó neve      : {0}", closest.Seller.Name);
            Console.WriteLine("\tEladó telefonja : {0}", closest.Seller.Phone);
            Console.WriteLine("\tAlapterület     : {0}", closest.Area);
            Console.WriteLine("\tSzobák száma    : {0}", closest.Floors);
        }
    }
}
