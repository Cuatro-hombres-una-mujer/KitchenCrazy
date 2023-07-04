using UnityEngine;

namespace Helper
{
    public class IdentifierUtility
    {

        private const int DefaultQuantity = 5;
        
        private static readonly char[] Chars =
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'r', 'o', '1', '2', '3', '4', '5',
            '6', '7', '8', '9'
        };

        public static string GenerateRandoId(int quantity)
        {

            if (quantity < 1)
            {
                return string.Empty;
            }
            
            var randomValue = Random.Range(0, Chars.Length);
            
            if (quantity == 1)
            {
                return Chars[randomValue].ToString();
            }

            return GenerateRandoId(quantity - 1) + Chars[randomValue];
        }
    
        public static string GenerateRandoId()
        {
            return GenerateRandoId(DefaultQuantity);
        }


    }



}