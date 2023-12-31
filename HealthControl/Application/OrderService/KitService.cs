
using Contract;
using Contract.Query;
using Contract.Services;
using Contract.ViewModel.Order.Kit;
using Contract.ViewModel.User;
using Domain.Model;
using Domain.Model.Order.Kit;
using Domain.Model.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Application.OrderService
{
    public class KitService : IKitService
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public KitService(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        public bool AddKit(CreateKitDto dto)
        {

            Kit kit = new Kit();
            kit.AddKit(dto.Serial, dto.Description, dto.Guidline, DTOJsonSerialize<List<TestType>>.GetJson(dto.TestTypes));
           
            _unitOfWork.BeginTransaction();
          
            _mediator.Send(kit);

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
