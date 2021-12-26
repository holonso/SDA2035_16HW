using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization;

namespace SDA2035_16HW
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;                        //константа количества товаров
            Product[] products = new Product[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите код продукта: ");
                int code = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите название продукта: ");
                string name = Console.ReadLine();
                Console.WriteLine("Введите цену продукта: ");
                double price = Convert.ToDouble(Console.ReadLine());

                products[i] = new Product() { ProductCode = code, ProductName = name, ProductPrice = price };
            }

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(products, options);
            using (StreamWriter sw = new StreamWriter("../../../Products.json", false))
            {
                sw.WriteLine(jsonString);
            }
        }
    }
}
