using Models;
using System.Globalization;

namespace Services
{
    public class OrderService
    {
        public static List<Order> ReadOrdersFromCsv(string filePath)
        {
            List<Order> orders = new List<Order>();

            foreach (var line in File.ReadLines(filePath))
            {
                var fields = line.Split(',');

                if (fields.Length == 4 &&

                    DateTime.TryParseExact(fields[3], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime deliveryTime) &&

                    double.TryParse(fields[1], out double weight))
                {
                    var order = new Order(fields[0], weight, fields[2], deliveryTime);
                    orders.Add(order);
                }
            }

            return orders;
        }
    }
}
