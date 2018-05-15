using Newtonsoft.Json;
using Solid01.SRP.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Solid01.SRP.Services
{
    class OrderStorage
    {


        public static void ProcessOrderInDb(OrderModel order, DbConnection dbConnection)
        {
            var cmd = dbConnection.CreateCommand();
            cmd.CommandText = @"exec processOrder";
            int generatedOrderId = cmd.Parameters.Add(JsonConvert.SerializeObject(order));
            order.OrderId = generatedOrderId;
        }
    }
}
