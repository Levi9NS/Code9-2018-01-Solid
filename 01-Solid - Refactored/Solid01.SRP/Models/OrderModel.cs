using System.Collections.Generic;

namespace Solid01.SRP.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }

        public List<OrderItemModel> OrderItems { get; set; }

        public OrdererInfoModel Orderer { get; set; }
    }
}
