

using Contract;
using Contract.Extenstion;
using Contract.Query;
using Contract.Services;
using Contract.ViewModel.Order.Cart;
using Contract.ViewModel.Order.Discount;
using Contract.ViewModel.Order.Kit;
using Contract.ViewModel.Order.KitRules;
using Contract.ViewModel.User;
using Domain.DomainService;
using Domain.Model;
using Domain.Model.Order.Kit;
using Domain.Model.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OrderService
{
    public class CartService : ICartService
    {
        private readonly IMediator _mediator;
        private readonly IKitRulesQuery _kitRulesQuery;
        private readonly IDiscountQuery _discountQuery;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDiscountDomainService _domainService;
        private readonly IUserQuery _userQuery;
        private readonly ICartQuery _cartQuery;

        public CartService(IMediator mediator,IUnitOfWork unitOfWork
            , IKitRulesQuery kitRulesQuery,
             IDiscountQuery discountQuery,
            IDiscountDomainService domainService, IUserQuery userQuery, ICartQuery cartQuery)
        {
            _mediator = mediator;
            _kitRulesQuery = kitRulesQuery;
            _discountQuery = discountQuery;
            _unitOfWork = unitOfWork;
            _domainService = domainService;
            _userQuery = userQuery;
            _cartQuery = cartQuery;
        }

        public bool AddCart(CreateCartDto dto)
        {
            long totalPrice = 0;
            foreach (var item in dto.CartItemList)
            {
                var rule = _kitRulesQuery.GetKitRules(item.KitId);
                if (rule != null)
                {
                    totalPrice += rule.Price * item.Count;
                }
            }

            DiscountDto discount = _discountQuery.GetValidDiscount(totalPrice);
            UserDto userInfo = _userQuery.GetById(dto.UserId);
            
            long price = _domainService.CalculateTotalPrice(discount.ToDiscount(), userInfo.ToUser(), totalPrice);
            Address address = new Address(dto.DeliveryAddress, new Country(dto.CountryName, (int)dto.Currency));


            Cart cart = new Cart();
            cart.AddCart(dto.UserId, price , CartStatus.Pending,address);
          
            _unitOfWork.BeginTransaction();
          
            _mediator.Send(cart);

            cart.CreateCartEvent(dto.CartItemList.ToCartItemList());

            foreach (var item in cart.GetEvents())
            {
                _mediator.Send(item);
            }

            var result = _unitOfWork.CommitTransaction();

            if (result)
            {
                return true;
            }
            else
            {
                _unitOfWork.Rollback();
                return false;
            }

            return true;
        }

        public CartDto? GetCartById(int id)
        {
            return _cartQuery.GetCartById(id);
        }

    }
}
