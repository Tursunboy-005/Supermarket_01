using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductDbService db = new ProductDbService();

            db.ReadAllProducts();
            Console.WriteLine();

            db.GetProductById(1);

            db.GetProductsByCategoryId(1);

            //db.CreateProduct("CocaCola", 25000);
            //Console.WriteLine();

            //db.ReadAllProducts();
            //Console.WriteLine();

            //db.UpdateProduct(1, "Water", 50000);
            //Console.WriteLine();

            //db.ReadAllProducts();
            //Console.WriteLine();

            //db.DeleteProduct(6);
            //db.ReadAllProducts();

            Console.ReadKey();
        }
    }
}
