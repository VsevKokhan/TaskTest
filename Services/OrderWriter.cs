using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderWriter
    {
        public static void WriteOrdersToCsv(string filePath, List<Order> orders)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var order in orders)
                {
                    writer.WriteLine($"{order.OrderId},{order.Weight},{order.District},{order.DeliveryTime:yyyy-MM-dd HH:mm:ss}");
                }
            }
        }
    }
}
