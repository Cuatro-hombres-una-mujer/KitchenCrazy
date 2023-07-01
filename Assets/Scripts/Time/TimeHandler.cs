namespace DefaultNamespace.Time
{
    public class TimeHandler
    {
        private int _seconds;

        public TimeHandler(int seconds)
        {
            _seconds = seconds;
        }

        public void DiscountSecond()
        {
            _seconds--;
        }

        public void ExpandSeconds(int additionalSeconds)
        {
            _seconds = _seconds + additionalSeconds;
        }

        public void FormatTime()
        {
            
        }
        
    }
}