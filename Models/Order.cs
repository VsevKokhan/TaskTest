﻿namespace Models
{
    public class Order
    {
        public string OrderId { get; set; }
        public double Weight { get; set; }
        public string District { get; set; }
        public DateTime DeliveryTime { get; set; }

        public Order(string orderId, double weight, string district, DateTime deliveryTime)
        {
            OrderId = orderId;
            Weight = weight;
            District = district;
            DeliveryTime = deliveryTime;
        }
    }
}
