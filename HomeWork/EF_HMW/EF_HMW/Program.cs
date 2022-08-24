using EF_HMW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindApp
{
    internal class EF_HMW
    {
        NorthwindContext db = new NorthwindContext();
        public void RunHMWCode()
        {

            //Exc.1
            Console.WriteLine("_______________ EXCERCISE 1 _______________\n");
            var exc1 = from item in db.Products
                       select new { item.ProductName, item.QuantityPerUnit };

            //Exc.2
            Console.WriteLine("_______________ EXCERCISE 2 _______________\n");
            var exc2 = from item in db.Products
                       where item.Discontinued == false
                       select new { item.ProductId, item.ProductName };

            //Exc.3
            Console.WriteLine("_______________ EXCERCISE 3 _______________\n");
            var exc3 = from item in db.Products
                       where item.Discontinued == true
                       select new { item.ProductId, item.ProductName };

            //Exc.4
            Console.WriteLine("_______________ EXCERCISE 4 _______________\n");
            var exc4 = (from item in db.Products
                        join prd in db.Products
                        on item.ProductId equals prd.ProductId
                        orderby item.UnitPrice descending
                        select new
                        {
                            prd.ProductName,
                            item.UnitPrice,

                        }).ToList();

            //Exc.5
            Console.WriteLine("_______________ EXCERCISE 5 _______________\n");
            var exc5 = from item in db.Products
                       where item.UnitPrice < 20
                       select new { item.ProductId, item.ProductName, item.UnitPrice };

            //Exc.6
            Console.WriteLine("_______________ EXCERCISE 6 _______________\n");
            var exc6 = from item in db.Products
                       where item.UnitPrice > 15 && item.UnitPrice < 25
                       select new { item.ProductId, item.ProductName, item.UnitPrice };

            //Exc.7
            Console.WriteLine("_______________ EXCERCISE 7 _______________\n");
            var exc7 = from item in db.Products
                       where item.UnitPrice > db.Products.Average(x => x.UnitPrice)
                       select new { item.ProductName, item.UnitPrice };

            //Exc.8
            Console.WriteLine("_______________ EXCERCISE 8 _______________\n");
            var exc8 = db.Products.Join(db.Products,
               x => x.ProductId,
               x => x.ProductId,
               (pUnitPrice, pName) => new
               {
                   pName.ProductName,
                   pUnitPrice.UnitPrice
               }
               ).OrderByDescending(x => x.UnitPrice).Take(10).ToList();

            //Exc.9
            Console.WriteLine("_______________ EXCERCISE 9 _______________\n");
            var exc9 = (from item in db.Products
                        where item.Discontinued == false
                        select item.ProductName).Count();

            var exc9p2 = (from item in db.Products
                          where item.Discontinued == true
                          select item.ProductName).Count();


            //Exc.10
            Console.WriteLine("_______________ EXCERCISE 10 _______________\n");
            var query = from item in db.Products
                        where item.Discontinued == false && item.UnitsInStock < item.UnitsOnOrder
                        select new { item.ProductId, item.UnitsOnOrder, item.UnitsInStock };

        }
    }
}
