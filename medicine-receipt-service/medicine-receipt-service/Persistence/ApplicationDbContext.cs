using medicine_receipt_service.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace medicine_receipt_service.Persistence
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
                substanceForProduction.HasKey(data => data.Id);
                substanceForProduction.Property(data => data.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAdd();
                substanceForProduction.Property(data => data.UpdateDate)
                .HasColumnType("timestamp without time zone")
                .ValueGeneratedOnAddOrUpdate();

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
                productionSteps.Property(data => data.Name)
                .HasMaxLength(100);

                productionSteps.Property(data => data.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAdd();

                productionSteps.Property(data => data.UpdateDate)
                .HasColumnType("timestamp without time zone")
                .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<ReceiptsEntity>(receipts =>
            {
                receipts.Property(data => data.Name)
                .HasMaxLength(100);

                receipts.Property(data => data.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAdd();

                receipts.Property(data => data.UpdateDate)
                .HasColumnType("timestamp without time zone")
                .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<SubstancesEntity>(substances =>
            {
                substances.Property(data => data.Name)
                .HasMaxLength(100);

                substances.Property(x => x.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAdd();

                substances.Property(x => x.UpdateDate)
                .HasColumnType("timestamp without time zone")
                .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<UsersEntity>(users =>
            {
                users.Property(data => data.Username)
                .HasMaxLength(20);

                users.Property(data => data.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAdd();

                users.Property(data => data.UpdateDate)
                .HasColumnType("timestamp without time zone")
                .ValueGeneratedOnAddOrUpdate();
            });


        }
    }
}
