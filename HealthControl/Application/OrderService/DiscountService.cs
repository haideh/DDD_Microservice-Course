

using Contract;
using Contract.Query;
using Contract.Services;
using Contract.ViewModel.Order.Discount;
using Contract.ViewModel.Order.Kit;
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
    public class DiscountService : IDiscountService
    {
        private readonly IMediator _mediator;

        private readonly IUnitOfWork _unitOfWork;


        public DiscountService(IMediator mediator,IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
         
            _unitOfWork = unitOfWork;
        }

        public bool AddDiscount(CreateDiscountDto dto)
        {
            Discount discount = new Discount();
            discount.AddDiscount(dto.MaxValue, dto.MinValue, dto.DiscountPercent, dto.StartDate,dto.EndDate);

            _unitOfWork.BeginTransaction();

            _mediator.Send(discount);

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
        }

    }
}
