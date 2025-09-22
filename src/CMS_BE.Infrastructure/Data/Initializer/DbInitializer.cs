using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS_BE.Application.Common.Interfaces.UnitOfWorks;
using CMS_BE.Domain.Aggregates.Auth;
using CMS_BE.Domain.Aggregates.Auth.Enums;
using CMS_BE.Domain.Aggregates.Humans.Enums;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace CMS_BE.Infrastructure.Data.Initializer
{
    public class DbInitializer
    {
        public static async Task InitializeAsync(IServiceProvider provider)
        {
            var unitOfWork = provider.GetRequiredService<IUnitOfWork>();
            var logger = provider.GetRequiredService<ILogger>();

            using var dbTransaction = await unitOfWork.BeginTransactionAsync();

            try
            {
                if (!await unitOfWork.Repository<Account>().AnyAsync())
                {
                    logger.Information("Seeding user data is starting.............");

                    List<Account> users = InitializeAccountDataAsync();

                    await unitOfWork.Repository<Account>().AddRangeAsync(users);
                    await unitOfWork.SaveAsync();

                    logger.Information("Seeding user data has finished.............");
                }
                await unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackAsync();
                logger.Information("error had occured while seeding data with {message}", ex);
                throw;
            }
        }

        private static List<Account> InitializeAccountDataAsync()
        {
            List<Account> users = new()
            {
                new Account("admin123", HashPassword("Admin@123"), Role.Admin, "Admin")
                {
                    Gender = Gender.Male,
                },
                new Account("doctorquang", HashPassword("Quang@2902"), Role.Doctor, "Quang")
                {
                    Gender = Gender.Male,
                },
                new Account("staffjohn", HashPassword("Chon@123"), Role.Staff, "John")
                {
                    Gender = Gender.Male,
                },
            };

            return users;
        }
    }
}
