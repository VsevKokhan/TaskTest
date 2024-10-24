using Models;
using Logs;
using Services;
using DotNetEnv;

namespace DeliveryApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            // !!!указываем путь к env файлу!!!
            Env.Load("");

            string cityDistrict = Environment.GetEnvironmentVariable("CITY_DISTRICT");
            string firstDeliveryDateTimeStr = Environment.GetEnvironmentVariable("FIRST_DELIVERY_DATETIME");
            string deliveryLogPath = Environment.GetEnvironmentVariable("DELIVERY_LOG");
            string orderFilePath = Environment.GetEnvironmentVariable("ORDER_FILE");

            if (!Directory.Exists(Path.GetDirectoryName(deliveryLogPath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(deliveryLogPath));
            }


            Logger logger = new Logger(deliveryLogPath);
            logger.Log("Программа запущена");

            DateTime firstDeliveryDateTime;
            if (!DateTime.TryParseExact(firstDeliveryDateTimeStr, "yyyy-MM-dd HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out firstDeliveryDateTime))
            {
                logger.Log("Некорректный формат времени.");
                return;
            }

            List<Order> orders = OrderService.ReadOrdersFromCsv(orderFilePath); ;
            logger.Log($"Загружено заказов: {orders.Count}");

            List<Order> filteredOrders = OrderFilter.FilterOrders(orders, cityDistrict, firstDeliveryDateTime);
            logger.Log($"Отфильтровано заказов: {filteredOrders.Count}");

            // Запись отфильтрованных заказов в файл
            string resultFilePath = "filtered_orders.csv"; // !!!Путь для сохранения результатов!!!
            OrderWriter.WriteOrdersToCsv(resultFilePath, filteredOrders);
            logger.Log($"Результаты фильтрации сохранены в {resultFilePath}");

            logger.Log("Программа завершена");
        }
    }
}
