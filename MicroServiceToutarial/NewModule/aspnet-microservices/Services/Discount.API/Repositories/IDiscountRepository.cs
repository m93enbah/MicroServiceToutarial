﻿using Discount.API.Entities;
using System.Threading.Tasks;

namespace Discount.API.Repositories
{
    public interface IDiscountRepository
    {
        Task<Coupon> GetDiscount(string productName);
        Task<bool> CreateDiscount(Coupon data);
        Task<bool> UpdateDiscount(Coupon data);
        Task<bool> DeleteDiscount(string productName);
    }
}
