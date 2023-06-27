using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Food.Order
{
    public class OrderGenerator
    {

        private const int MaxOrderRequested = 3;
        private const int MaxQuantity = 3;
        
        private readonly List<ItemFood> _items;

        public OrderGenerator(List<ItemFood> items)
        {
            
            _items = new List<ItemFood>();

            foreach (var item in items)
            {
                
                if (item.RequestedForClient)
                {
                    _items.Add(item);
                }

            }
        }

        public List<Order> Generate()
        {

            var orders = new List<Order>();
            var itemsCloned = new List<ItemFood>(_items);

            var countOrders = Random.Range(1, MaxOrderRequested);
            for (var i = 0; i < countOrders; i++)
            {

                var elementRandomPosition = Random.Range(0, itemsCloned.Count);
                var itemFood = itemsCloned[elementRandomPosition];

                itemsCloned.Remove(itemFood);

                var quantityRandom = Random.Range(1, MaxQuantity);
                itemFood.Quantity = quantityRandom;

                var order = new Order(itemFood);
                orders.Add(order);

            }

            return orders;
        }

    }

}