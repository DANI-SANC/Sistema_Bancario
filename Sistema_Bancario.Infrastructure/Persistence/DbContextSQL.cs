using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sistema_Bancario.Dominio;

namespace Sistema_Bancario.Infrastructure.Persistence
{
    public class DbContextSQL : DbContext
    {

        public DbContextSQL(DbContextOptions<DbContextSQL> options) : base(options) { }
        /*
        public DbContextSQL() : base(new DbContextOptionsBuilder<DbContextSQL>()
            .UseSqlServer("Server=localhost;Database=Sistema_Bancario_QA;User Id=sa;Password=Sql@Server2024;TrustServerCertificate=True")
            .Options)
        {
        }
        */

        public DbSet<AplicationUser>?  AplicationUsers {  get; set; }
        public DbSet<Role>? Roles { get; set; }
        public DbSet<CuentaBancaria>? CuentaBancarias { get; set; }
        public DbSet<Transaccion>? Transacciones {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AplicationUser>().HasOne(r => r.Role).WithMany(u => u.AplicationUsers).
                HasForeignKey(r => r.Id).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CuentaBancaria>().HasOne(c => c.Cliente).WithMany(cb => cb.CuentaBancaria).
               HasForeignKey(c => c.ClienteId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaccion>().HasOne(cb => cb.CuentaBancaria).WithMany(t => t.Transaccion).
                HasForeignKey(cb => cb.CuentaBancariaId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CuentaBancaria>().Property(cb => cb.Saldo).HasColumnType("decimal(18,2)");
            
            modelBuilder.Entity<Transaccion>().Property(t => t.Monto).HasColumnType("decimal(18,2)");
        }


 
        


    }
}
