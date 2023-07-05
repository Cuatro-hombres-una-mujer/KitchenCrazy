using System;

namespace Helper
{
    public class ParserHelper
    {
        
        public static T ParseEnum<T>(string value)
        {
            return (T) Enum.Parse(typeof(T), value, true);
        }
        
    }
    
}