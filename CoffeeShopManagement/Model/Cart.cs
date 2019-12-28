using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Cart
    {
        Dictionary<string, int> cart;

        public float Total { get; set; }
        
        public int Size { get { return cart.Count; } }

        public Cart()
        {
            cart = new Dictionary<string, int>();
        }

        public void RemoveCart(string id)
        {
            if (cart.ContainsKey(id))
            {
                cart.Remove(id);
                
            }
            if (this.cart.Count == 0)
            {
                this.cart = null;
            }
        }

        public void AddToCart(string id)
        {
            int quantity = 1;
            if (cart.ContainsKey(id))
            {
                quantity += cart[id];
                cart[id] = quantity;
            }
            else
                cart.Add(id, quantity);
        }

        public void AddtoCart(string id, int quantity)
        {
            cart.Add(id, quantity);
        }

        public List<CoffeeDTO> GetCartDetail()
        {
            if(cart == null)
            {
                return null;
            }
            Total = 0;
            List<CoffeeDTO> detail = new List<CoffeeDTO>();
            foreach (var key in cart.Keys)
            {
                CoffeeDAO dao = new CoffeeDAO();
                CoffeeDTO coffee = dao.GetCoffeeByID(key);
                coffee.QuantityCart = cart[key];
                coffee.Total = coffee.price * coffee.QuantityCart;
                Total += coffee.Total;
                detail.Add(coffee);
            }
            return detail;
        }

        public void UpdateCart(string id, int quantity)
        {
            if (cart.ContainsKey(id))
            {
                cart[id] = quantity;
            }
        }

        public void Put(string coffeeId, int quantity)
        {
            this.cart.Add(coffeeId, quantity);
        }

        public int GetQuantity(string id)
        {
            return cart[id];
        }
    }
}