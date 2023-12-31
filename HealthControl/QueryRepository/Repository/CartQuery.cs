using Contract.Query;
using Contract.ViewModel.Order.Cart;
using Contract.ViewModel.Order.KitRules;
using Contract.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace QueryRepository.Repository
{
    public class CartQuery : ICartQuery
    {
        private readonly HealthQueryContext _context;


        public CartQuery(HealthQueryContext context)
        {
            _context = context;
        }



        public CartDto? GetCartById(int id)
        {
            var cart = _context.Carts.Where(x => x.Id == id).Select(x => new CartDto()
            {
                UserId = x.UserId,
                Id = x.Id,
                Date = x.Date,
                DeliveryAddress = x.DeliveryAddress,
                Price = x.Price,
                Status = x.Status,

            }).FirstOrDefault();
            if (cart != null)
            {
                cart.CartItems = new List<CartItemDto>();
                cart.CartItems = _context.CartItems.Where(x => x.CartId == id).Select(x => new CartItemDto()
                {
                    CartId = x.CartId,
                    Id = x.Id,
                    Count = x.Count,
                    KitId = x.KitId
                }).ToList();
                return cart;
            }
            return null;

        }

    }
}
