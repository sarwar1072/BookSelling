using System;
using System.Collections.Generic;
using System.Text;
using Framework.Entities;
using Microsoft.EntityFrameworkCore;

namespace Framework
{
   public  class FrameworkContext:DbContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public FrameworkContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<StudentRegistration>()
            //     .HasKey(sm => sm.Id);

            //builder.Entity<StudentRegistration>()
            //    .HasOne(sr => sr.Course)
            //    .WithMany(x => x.StudentRegistrations)
            //    .HasForeignKey(sr => sr.CourseId);

            //builder.Entity<StudentRegistration>()
            //    .HasOne(sr => sr.Student)
            //    .WithMany(x => x.StudentRegistrations)
            //    .HasForeignKey(sr => sr.StudentId);

            base.OnModelCreating(builder);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CoverType> CoverTypes { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }


    }
}
