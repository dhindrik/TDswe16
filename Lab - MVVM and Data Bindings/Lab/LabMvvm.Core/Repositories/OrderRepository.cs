using LabMvvm.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabMvvm.Core.Repositories
{
    /// <summary>
    /// This repository is just for demo purposes
    /// </summary>
    public class OrderRepository
    {
        // Simulate a database
        private static bool _mockDataInitialized = false;
        private static IList<Order> _orders = new List<Order>();

        public OrderRepository()
        {
            // Add some seed data
            if(!_mockDataInitialized)
            {
                _orders.Add(new Models.Order() { Id = 1, Customer = "Bob", CreateDate = DateTime.Now.AddHours(-15), OrderDate = null});
                _orders.Add(new Models.Order() { Id = 2, Customer = "Alice", CreateDate = DateTime.Now.AddHours(-8), OrderDate = null });
                _orders.Add(new Models.Order() { Id = 3, Customer = "Todd", CreateDate = DateTime.Now.AddHours(-20), OrderDate = null, Status = OrderStatus.Ordered });
                _mockDataInitialized = true;
            }
        }

        public async Task Create(string customer, string orderText)
        {
            await Task.Delay(1);

            var maxId = _orders.Max(e => e.Id) + 1;
            _orders.Add(new Models.Order() { Id = maxId, Customer = customer, OrderText = orderText });
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            // Mock delay
            await Task.Delay(1);
            return CloneObject(_orders);
        }

        public async Task<Order> GetOrderAsync(int orderId)
        {
            // Mock delay
            await Task.Delay(1);
            return CloneObject(_orders.FirstOrDefault(e => e.Id == orderId));
        }

        /// <summary>
        /// Clone the object to avoid direct references to objects
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        private T CloneObject<T>(T source)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(source);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }
    }
}
