using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Helper
{
    public class ListHelper
    {

        public static int GetLastPositionInCollection<T>(List<T> collection)
        {
            return collection.Count - 1;
        }
        
    }
}