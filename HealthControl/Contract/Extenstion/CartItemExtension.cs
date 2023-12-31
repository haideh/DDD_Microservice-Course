using Contract.ViewModel.Order.Cart;
using Contract.ViewModel.User;
using Domain.Model.Order.Kit;
using Domain.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Extenstion
{
    public static class CartItemExtension
    {
        public static List<CartItem> ToCartItemList(this List<CreateCartItemDto> dto)
        {
            List<CartItem> result = new List<CartItem>();
            foreach (var item in dto)
            {
                result.Add(ToCartItem(item));
            }
            return result;
        }
        public static CartItem ToCartItem(this CreateCartItemDto dto)
        {
            if(dto==null)
                return new CartItem();
            return new CartItem(dto.KitId,dto.Count);

        }
    }
}
