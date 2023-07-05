using System.Collections.Generic;
using Food;
using Food.Order;
using UnityEngine;

namespace Entities
{
    public class Client
    {
        private List<Order> _orders;
        private bool _isWalking;
        public string NameGameObject { get; }
        public string Name { get; set; }

        public bool IsViewOrder { get; set; }

        public GameObject ClientObject { get; set; }
        public GameObject BubbleGameObject { get; set; }
        public GameObject BubbleTextGameObject { get; set; }
        private SpriteRenderer _spriteRenderer;
        
        public Client(bool isWalking, string name, string realName,
            GameObject bubbleGameObject, GameObject bubbleTextGameObject,
            GameObject clientObject)
        {
            BubbleGameObject = bubbleGameObject;
            BubbleTextGameObject = bubbleTextGameObject;
            _isWalking = isWalking;
            NameGameObject = name;
            Name = realName;
            ClientObject = clientObject;

            _spriteRenderer = clientObject.GetComponent<SpriteRenderer>();
        }

        public void UpdateSprite(Sprite sprite)
        {
            _spriteRenderer.sprite = sprite;
        }
        
        public void SetOrders(List<Order> orders)
        {
            _orders = orders;
        }

        public void StartWalk()
        {
            _isWalking = true;
        }

        public void StopWalk()
        {
            _isWalking = false;
        }

        public bool IsWalking()
        {
            return _isWalking;
        }

        public bool SawOrder()
        {
            return IsViewOrder;
        }
        public void ViewOrder()
        {
            IsViewOrder = true;
            
            Debug.Log("Viendo la orden");
            BubbleGameObject.SetActive(false);
            BubbleTextGameObject.SetActive(false);
        }

        public void UnViewOrder()
        {
            IsViewOrder = true;
            
            BubbleGameObject.SetActive(true);
            BubbleTextGameObject.SetActive(true);
        }
        
        public List<Order> GetOrders()
        {
            return _orders;
        }

        public bool AllOrdersAreReady()
        {
            foreach (var order in _orders)
            {
                if (!order.IsReady)
                {
                    return false;
                }
            }

            return true;
        }
    }
}