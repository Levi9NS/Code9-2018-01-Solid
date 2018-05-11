namespace Solid02.OCP
{
    public class OrderItem
    {
        public string Name { get; set; }
        public string UnitOfMeasure { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string DiscountType { get; set; } = DiscountTypes.NoDiscount;
    }
}
