using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bank.Infrastructure
{
    public class CustomerSeed : IEntityTypeConfiguration<Customer>

    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer { 
                id = Guid.Parse("a3c3b282-6b6e-4a85-8a3e-74e58a6a9b01"),
                Name="Tejas",
                Email="tejas@gmail.com",
                KeyStatus=true,
                Status=0,
                CreatedOnUtc=DateTime.UtcNow
                },
                new Customer
                {
                    id = Guid.Parse("b4d4c393-7c7f-5b96-9b4f-85f69b7b0c12"),
                    Name = "John Doe",
                    Email = "om@gmail.com",
                    KeyStatus =true,
                    Status = 0,
                    CreatedOnUtc = DateTime.UtcNow
                }
            );


        }
    }
}
