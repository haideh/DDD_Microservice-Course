using Contract.ViewModel.Order.Discount;
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
    public static class DiscountExtension
    {
        public static Discount ToDiscount(this DiscountDto dto)
        {
            if (dto == null)
                return new Discount();
            return new Discount(dto.Id,dto.MaxValue, dto.MinValue, dto.DiscountPercent, dto.StartDate, dto.EndDate);

        }

    }
}
