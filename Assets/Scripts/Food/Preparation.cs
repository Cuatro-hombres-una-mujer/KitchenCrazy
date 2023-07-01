namespace Food
{
    public class Preparation
    {
    
        public ItemFood Item { get; set; }
        public ItemFood ItemCooked { get; set; }
        public int Seconds { get; set; }

        public Preparation(ItemFood item, ItemFood itemCooked, int seconds)
        {
            Item = item;
            ItemCooked = itemCooked;
            Seconds = seconds;
        }

    }
    
}