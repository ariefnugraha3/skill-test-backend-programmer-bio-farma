using medicine_receipt_service.Contexts.Entities;
using Microsoft.EntityFrameworkCore;

namespace medicine_receipt_service.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<ProductionStepsEntity> ProductionStepsEntities => Set<ProductionStepsEntity>();
        public DbSet<ReceiptsEntity> ReceiptsEntities => Set<ReceiptsEntity>();
        public DbSet<SubstancesEntity> SubstancesEntities => Set<SubstancesEntity>();
        public DbSet<SubstancesForProductionEntity> SubstancesForProductionEntities => Set<SubstancesForProductionEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SubstancesForProductionEntity>(substanceForProduction =>
            {
                substanceForProduction.ToTable("substance_for_productions");

                //relation to Receipt
                substanceForProduction.HasOne(data => data.ReceiptsEntity)
                .WithMany(receipt => receipt.SubstancesForProductions)
                .HasForeignKey(data => data.ReceiptId)
                .OnDelete(DeleteBehavior.Cascade);

                //relation to Substance
                substanceForProduction.HasOne(data => data.SubstancesEntity)
                .WithMany(substance => substance.SubstancesForProductions)
                .HasForeignKey(data => data.SubstanceId)
                .OnDelete(DeleteBehavior.Cascade);

                //relation to ProductionStep
                substanceForProduction.HasOne(data => data.ProductionStepsEntity)
                .WithMany(step => step.SubstancesForProductions)
                .HasForeignKey(data => data.ProductionStepId)
                .OnDelete(DeleteBehavior.Cascade);

                substanceForProduction.HasIndex(data => new { data.ReceiptId, data.SubstanceId, data.ProductionStepId })
                .IsUnique();
            });

            modelBuilder.Entity<ProductionStepsEntity>(productionSteps =>
            {
                productionSteps.ToTable("production_steps");

                productionSteps.Property(data => data.Name)
                .HasMaxLength(100);
            });

            modelBuilder.Entity<ReceiptsEntity>(receipts =>
            {
                receipts.ToTable("receipts");

                receipts.Property(data => data.Name)
                .HasMaxLength(100);
            });

            modelBuilder.Entity<SubstancesEntity>(substances =>
            {
                substances.ToTable("substances");

                substances.Property(data => data.Name)
                .HasMaxLength(100);
            });

            modelBuilder.Entity<UsersEntity>(users =>
            {
                users.ToTable("users");

                users.Property(data => data.Username)
                .HasMaxLength(20);
            });


        }
    }
}
