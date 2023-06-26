using System.Collections;
using System.Collections.ObjectModel;
using System.Text;

namespace Helper
{
    public class StringHelper
    {

        public const string SpaceLine = "\n";
        
        public static string ConvertToString(IEnumerable collection)
        {

            var stringBuilder = new StringBuilder();
            foreach (var value in collection)
            {
                stringBuilder.Append(value)
                    .Append(SpaceLine);
            }

            RemoveLastCharacterAtStringBuilder(stringBuilder);
            return stringBuilder.ToString();
        }

        public static void RemoveLastCharacterAtStringBuilder(StringBuilder stringBuilder)
        {
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
        }
        
    }
    
}