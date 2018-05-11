using Newtonsoft.Json;
using Solid05.DIP.Models;
using System;
using System.Data.Common;

namespace Solid05.DIP.Services
{
    public class OrderProcessorStore : IOrderProcessorStore
    {
        private readonly DbConnection _dbConnection;

        public OrderProcessorStore(DbConnection dbConnection)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
        }

        public void ProcessOrderInStorage(OrderModel order)
        {
            var cmd = _dbConnection.CreateCommand();
            cmd.CommandText = @"exec processOrder";
            int generatedOrderId = cmd.Parameters.Add(JsonConvert.SerializeObject(order));
            order.OrderId = generatedOrderId;
        }
    }
}
