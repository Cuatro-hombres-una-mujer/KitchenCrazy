namespace Food.Order
{
    public class Order
    {
        public ItemFood ItemOrdered { get; }
        public bool Ready { get; set; }

        public Order(ItemFood itemFood)
        {
            ItemOrdered = itemFood;
            Ready = false;

        }
    }
}