using System.Collections.Generic;
using System.Text;
using Food;

namespace Helper
{
    public class ItemHelper
    {

        private const string Space = "\n";

        public static string GenerateListItems(List<ItemFood> items)
        {

            var stringBuilder = new StringBuilder();

            foreach (var item in items)
            {
                stringBuilder.Append(item.Name).Append(Space);
            }

            return stringBuilder.ToString();
        }

    }
    
}