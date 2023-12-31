

using Contract;
using Contract.Extenstion;
using Contract.Query;
using Contract.Services;
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
    public class KitRulesService : IKitRulesService
    {
        private readonly IMediator _mediator;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IKitQuery _kitQuery;
        private readonly IKitRulesDomainService _domainService;


        public KitRulesService(IMediator mediator,IUnitOfWork unitOfWork,
            IKitRulesDomainService domainService, IKitQuery kitQuery)
        {
            _mediator = mediator;
            _domainService = domainService;
            _kitQuery = kitQuery;

            _unitOfWork = unitOfWork;
        }

        public bool AddKitRules(CreateKitRulesDto dto)
        {
            KitDto? kitDto = _kitQuery.GetById(dto.KitId);

            KitRules kitRules = new KitRules();
            long price = _domainService.CalculateKitPrice(kitDto.TestType, dto.Country.ToCountry(),dto.Price);

            kitRules.AddKitsRule(price, dto.KitId, dto.Country.ToCountry());

            _unitOfWork.BeginTransaction();

            _mediator.Send(kitRules);

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
