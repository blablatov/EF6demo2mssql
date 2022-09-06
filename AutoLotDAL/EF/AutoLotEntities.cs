using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using AutoLotDAL.Models;
using System.Data.Entity.Infrastructure.Interception;
using AutoLotDAL.Interception;

namespace AutoLotDAL.EF
{
    public partial class AutoLotEntities : DbContext
    {
        //static readonly DatabaseLogger DatabaseLogger = new DatabaseLogger("sqllog.txt");
        public AutoLotEntities()
            : base("name=AutoLotConnection")
        {
            DbInterception.Add(new ConsoleWriterInterceptor());
            //DatabaseLogger.StartLogging();
            //DbInterception.Add(DatabaseLogger);
        }
        protected override void Dispose(bool disposing)
        {
            //DbInterception.Remove(DatabaseLogger);
            //DatabaseLogger.StopLogging();
            //base.Dispose(disposing);
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Cars { get; set; }
        public virtual DbSet<Order> Orders { get;  set; }
        public virtual DbSet<CreditRisk> CreditRisks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            {
                modelBuilder.Entity<Inventory>()
                    .HasMany(e => e.Orders)
                    .WithRequired(e => e.Car)
                    .WillCascadeOnDelete(false);
            }
        }
    }
}
