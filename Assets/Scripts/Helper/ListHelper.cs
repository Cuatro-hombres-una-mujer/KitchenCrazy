using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Helper
{
    public class ListHelper
    {

        public static int GetLastPositionInCollection<T>(List<T> collection)
        {
            return collection.Count - 1;
        }

        public static T RandomValueList<T>(List<T> list)
        {
            var valueInt = Random.Range(0, list.Count);
            return list[valueInt];
        }

    }
}