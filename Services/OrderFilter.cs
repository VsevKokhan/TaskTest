using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderFilter
    {
        public static List<Order> FilterOrders(List<Order> orders, string district, DateTime firstDeliveryDateTime)
        {
            DateTime timeLimit = firstDeliveryDateTime.AddMinutes(30);

            return orders
                .Where(order => order.District == district && order.DeliveryTime >= firstDeliveryDateTime && order.DeliveryTime <= timeLimit)
                .ToList();
        }
    }
}
