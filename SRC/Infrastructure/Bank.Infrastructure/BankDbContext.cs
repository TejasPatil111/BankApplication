using Bank.Application.Features.Account.AccountWithCustomerDto;
using Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bank.Infrastructure
{

    public class BankDbContext : DbContext
    {
        public BankDbContext(DbContextOptions<BankDbContext> options) : base(options) { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<LedgerEntry> LedgerEntiries { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<Money> Money { get; set; }
        public DbSet<AccountWithCustomerDto> AccountsWithCustomersDto { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.AccountNo).IsRequired().HasMaxLength(20);
                entity.Property(a => a.Currency).IsRequired().HasMaxLength(5);
                entity.Property(a => a.Balance).HasColumnType("decimal(18,2)");
                entity.Property(a => a.RowVersion).IsRowVersion();
                entity.Property(a => a.OpendOnUtc).IsRequired();
                entity.Property(a => a.Status).HasConversion<int>();

            });
            base.OnModelCreating(modelBuilder);

            // Apply all IEntityTypeConfiguration classes from assembly
            modelBuilder.Entity<Transfer>()
                .HasOne(t => t.FromAccount)
                .WithMany()
                .HasForeignKey(t => t.FromAccountId)
                .OnDelete(DeleteBehavior.Restrict);  // or NoAction

            modelBuilder.Entity<Transfer>()
                .HasOne(t => t.ToAccount)
                .WithMany()
                .HasForeignKey(t => t.ToAccountId)
                .OnDelete(DeleteBehavior.Restrict);  // or NoAction


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BankDbContext).Assembly);

           
            // Register keyless entity for DTO
            modelBuilder.Entity<AccountWithCustomerDto>(entity =>
            {
                entity.HasNoKey();
                entity.ToView(null); // Not mapped to a table or view
                entity.Property(e => e.Id);
                entity.Property(e => e.AccountNo);
                entity.Property(e => e.CustomerId);
                entity.Property(e => e.CustomerName);
                entity.Property(e => e.CustomerEmail);
                // Map other Customer properties similarly
            });
        


    }






}
}
