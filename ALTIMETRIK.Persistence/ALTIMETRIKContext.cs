using ALTIMETRIK.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace ALTIMETRIK.Persistence
{
    public partial class ALTIMETRIKContext :DbContext
    {
        public virtual DbSet<ZipUser> ZipUser { get; set; }
        public ALTIMETRIKContext(DbContextOptions<ALTIMETRIKContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ZipUser>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("PK_ZipUser");


                entity.Property(e => e.JobTitle)
                .HasColumnName("FirstName")
                .HasColumnType("varchar(50)");

                entity.Property(e => e.JobTitle)
               .HasColumnName("LastName")
               .HasColumnType("varchar(50)");


                entity.Property(e => e.JobTitle)
               .HasColumnName("Email")
               .HasColumnType("varchar(100)");


                entity.Property(e => e.JobTitle)
                .HasColumnName("JobTitle")
                .HasColumnType("varchar(50)");

                entity.Property(e => e.Phone)
                .HasColumnName("Phone")
                .HasColumnType("varchar(30)");

                entity.Property(e => e.MonthlySalary)
               .HasColumnName("MonthlySalary")
               .HasColumnType("money");

                entity.Property(e => e.MonthlyExpense)
                .HasColumnName("MonthlyExpense")
               .HasColumnType("money");

                entity.Property(e => e.ModifiedOn)
               .HasColumnName("ModifiedOn")
               .HasColumnType("datetime");

            });
        }
    }
}
