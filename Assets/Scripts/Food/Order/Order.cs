namespace Food.Order
{
    public class Order
    {
        public ItemFood ItemOrdered { get; }
        public bool IsReady { get; set; }

        public Order(ItemFood itemFood)
        {
            ItemOrdered = itemFood;
            IsReady = false;

        }
        
        public void Ready()
        {
            IsReady = true;
        }
        
    }
}