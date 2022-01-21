using Core.Entities.Concrete;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public class EmrOrgContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=127.0.0.1;port=3306;database=emrorg;uid=root;");
        }
       
        public DbSet<Brands> brand { get; set; }
        public DbSet<Categories> category { get; set; }
        public DbSet<Products> product { get; set; }
        public DbSet<ProductImages> product_image { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<UserOperationClaim> user_operation_claims { get; set; }
        public DbSet<OperationClaim> operation_claims { get; set; }
    }
}
