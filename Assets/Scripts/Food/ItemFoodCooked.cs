namespace Food
{
    public class ItemFoodCooked
    {
    
        public ItemFood Item { get; set; }
        public ItemFood ItemCooked { get; set; }
        public int Seconds { get; set; }

        public ItemFoodCooked(ItemFood item, ItemFood itemCooked, int seconds)
        {
            Item = item;
            ItemCooked = itemCooked;
            Seconds = seconds;
        }

    }
    
}