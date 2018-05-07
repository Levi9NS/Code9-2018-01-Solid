using System.Collections.Generic;

namespace Solid05.DIP.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }

        public List<OrderItemModel> OrderItems { get; set; }

        public OrdererInfoModel Orderer { get; set; }
    }
}
