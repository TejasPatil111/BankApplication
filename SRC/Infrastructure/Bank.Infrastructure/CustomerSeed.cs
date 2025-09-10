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
                id = 1,
                Name="Tejas",
                Email="tejas@gmail.com",
                KeyStatus=true,
                Status=0,
                CreatedOnUtc=DateTime.UtcNow
                },
                new Customer
                {
                    id = 2,
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
