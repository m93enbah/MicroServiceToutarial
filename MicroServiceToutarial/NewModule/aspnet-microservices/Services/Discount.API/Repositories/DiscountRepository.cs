using Dapper;
using Discount.API.Entities;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace Discount.API.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration Configuration;
        private readonly string ConnectionString;
        public DiscountRepository(IConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            ConnectionString = Configuration.GetValue<string>("DatabaseSettings:ConnectionString");
        }

        public async Task<Coupon> GetDiscount(string productName)
        {
            //we are using NpgSql from NgpSql pacakge for access POST Gress DB
            using var conn = new NpgsqlConnection(ConnectionString);
            //we are using Dapper to access to Post Gress DB
            var coupon = await conn.QueryFirstOrDefaultAsync<Coupon>("Select * from Coupon Where ProductName = @ProductName", new { ProductName = productName });

            if (coupon == null)
            {
                return new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount Desc" };
            }
            return coupon;
        }


        public async Task<bool> CreateDiscount(Coupon data)
        {
            //we are using NpgSql from NgpSql pacakge for access POST Gress DB
            using var conn = new NpgsqlConnection(ConnectionString);
            //we are using Dapper to access to Post Gress DB
            var affected = await conn.ExecuteAsync(
                "Insert into Coupon (ProductName,Description,Amount) values (@ProductName,@Description,@Amount)", 
                new { ProductName = data.ProductName,Description = data.Description, Amount = data.Amount });

            if (affected == 0)
            {
                return false;
            }

            return true;
        }


        public async Task<bool> UpdateDiscount(Coupon data)
        {
            using var conn = new NpgsqlConnection(ConnectionString);
            //we are using Dapper to access to Post Gress DB
            var affected = await conn.ExecuteAsync(
                "Update Coupon set ProductName = @ProductName , Description = @Description , Amount = @Amount where Id = @Id",
                new { ProductName = data.ProductName, Description = data.Description, Amount = data.Amount, Id = data.Id });

            if (affected == 0)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            using var conn = new NpgsqlConnection(ConnectionString);
            //we are using Dapper to access to Post Gress DB
            var affected = await conn.ExecuteAsync("delete from Coupon where ProductName = @ProductName", new { ProductName = productName });
            if (affected == 0)
            {
                return false;
            }
            return true;
        }
    }
}

