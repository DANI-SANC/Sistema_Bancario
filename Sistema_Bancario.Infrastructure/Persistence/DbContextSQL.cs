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
        public DbSet<AplicationUser>? AplicationUsers { get; set; }
        public DbSet<Role>? Roles { get; set; }
        public DbSet<CuentaBancaria>? CuentaBancarias { get; set; }
        public DbSet<Transaccion>? Transacciones { get; set; }

        public DbSet<TipoTransaccion>? TipoTransacciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AplicationUser>()
                .HasOne(r => r.Role)
                .WithMany(u => u.AplicationUsers)
                .HasForeignKey(r => r.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CuentaBancaria>()
                .HasOne(c => c.Cliente)
                .WithMany(cb => cb.CuentaBancaria)
                .HasForeignKey(c => c.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaccion>()
                .HasOne(cb => cb.CuentaBancaria)
                .WithMany(t => t.Transaccion)
                .HasForeignKey(cb => cb.CuentaBancariaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaccion>()
                .HasOne(tt => tt.TipoTransaccion)
                .WithMany(t => t.Transaccion)
                .HasForeignKey(tt => tt.TipoTransaccionId)
                .OnDelete(DeleteBehavior.Restrict);
                

            modelBuilder.Entity<CuentaBancaria>()
                .Property(cb => cb.Saldo)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Transaccion>()
                .Property(t => t.Monto)
                .HasColumnType("decimal(18,2)");

            CargarDataRolesBackend(modelBuilder); // Agregar datos iniciales de roles
        }

        private void CargarDataRolesBackend(ModelBuilder modelBuilder)
        {
            var AdministradorId = Guid.Parse("a1b2c3d4-e5f6-47a8-9b0c-d1e2f3a4b5c6").ToString();
            var CajeroVentanillaId = Guid.Parse("b2c3d4e5-f6a7-48b9-0c1d-e2f3a4b5c6a7").ToString();

           

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = AdministradorId,
                    Name = CustomRolesBackend.Administrador,
                    NormalizedName = CustomRolesBackend.Administrador
                }
            );

            modelBuilder.Entity<IdentityRole>().HasData(
             new IdentityRole
             {
                 Id = CajeroVentanillaId,
                 Name = CustomRolesBackend.CajeroVentanilla,
                 NormalizedName = CustomRolesBackend.CajeroVentanilla
             }

            );

            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(
            new IdentityRoleClaim<string>
            {
                Id=1,
                ClaimType = ClaimsRolesBackend.POLICIES,
                ClaimValue = PoliciesMaster.LEER_DEPOSITO,
                RoleId = AdministradorId,
            },

             new IdentityRoleClaim<string>
             {
                 Id = 2,
                 ClaimType = ClaimsRolesBackend.POLICIES,
                 ClaimValue = PoliciesMaster.LEER_DEPOSITO,
                 RoleId = CajeroVentanillaId,
             },

            new IdentityRoleClaim<string>
            {
                Id = 3,
                ClaimType = ClaimsRolesBackend.POLICIES,
                ClaimValue = PoliciesMaster.LEER_RETIRO,
                RoleId = AdministradorId,
            },

             new IdentityRoleClaim<string>
             {
                 Id = 4,
                 ClaimType = ClaimsRolesBackend.POLICIES,
                 ClaimValue = PoliciesMaster.LEER_RETIRO,
                 RoleId = CajeroVentanillaId,
             },

               new IdentityRoleClaim<string>
               {
                   Id = 5,
                   ClaimType = ClaimsRolesBackend.POLICIES,
                   ClaimValue = PoliciesMaster.RETIRO,
                   RoleId = CajeroVentanillaId,
               },
               new IdentityRoleClaim<string>
               {
                   Id = 6,
                   ClaimType = ClaimsRolesBackend.POLICIES,
                   ClaimValue = PoliciesMaster.RETIRO,
                   RoleId = AdministradorId,
               },
                new IdentityRoleClaim<string>
                {
                      Id = 7,
                      ClaimType = ClaimsRolesBackend.POLICIES,
                      ClaimValue = PoliciesMaster.DEPOSITO,
                      RoleId = AdministradorId,
                 },
                 new IdentityRoleClaim<string>
                 {
                     Id = 8,
                     ClaimType = ClaimsRolesBackend.POLICIES,
                     ClaimValue = PoliciesMaster.DEPOSITO,
                     RoleId = CajeroVentanillaId,
                 },
                 new IdentityRoleClaim<string>
                 {
                     Id = 9,
                     ClaimType = ClaimsRolesBackend.POLICIES,
                     ClaimValue = PoliciesMaster.LEER_ROL,
                     RoleId = AdministradorId,
                 },
                 new IdentityRoleClaim<string>
                 {
                     Id = 10,
                     ClaimType = ClaimsRolesBackend.POLICIES,
                     ClaimValue = PoliciesMaster.ELIMINAR_ROL,
                     RoleId = AdministradorId,
                 },
                new IdentityRoleClaim<string>
                {
                    Id = 11,
                    ClaimType = ClaimsRolesBackend.POLICIES,
                    ClaimValue = PoliciesMaster.MODIFICAR_ROL,
                    RoleId = AdministradorId,
                },
                new IdentityRoleClaim<string>
                {
                    Id = 12,
                    ClaimType = ClaimsRolesBackend.POLICIES,
                    ClaimValue = PoliciesMaster.REGISTRAR_ROL,
                    RoleId = AdministradorId,
                },
                new IdentityRoleClaim<string>
                 {
                     Id = 13,
                     ClaimType = ClaimsRolesBackend.POLICIES,
                     ClaimValue = PoliciesMaster.REGISTRAR_USUARIO,
                     RoleId = AdministradorId,
                 },
                 new IdentityRoleClaim<string>
                 {
                     Id = 14,
                     ClaimType = ClaimsRolesBackend.POLICIES,
                     ClaimValue = PoliciesMaster.MODIFICAR_USUARIO,
                     RoleId = AdministradorId,
                 },
                 new IdentityRoleClaim<string>
                 {
                     Id = 15,
                     ClaimType = ClaimsRolesBackend.POLICIES,
                     ClaimValue = PoliciesMaster.ELIMINAR_USUARIO,
                     RoleId = AdministradorId,
                 },
                 new IdentityRoleClaim<string>
                 {
                     Id = 16,
                     ClaimType = ClaimsRolesBackend.POLICIES,
                     ClaimValue = PoliciesMaster.LEER_USUARIO,
                     RoleId = AdministradorId,
                 },
                 new IdentityRoleClaim<string>
                 {
                     Id = 17,
                     ClaimType = ClaimsRolesBackend.POLICIES,
                     ClaimValue = PoliciesMaster.REGISTRAR_CUENTA,
                     RoleId = AdministradorId,
                 },
                 new IdentityRoleClaim<string>
                 {
                     Id = 18,
                     ClaimType = ClaimsRolesBackend.POLICIES,
                     ClaimValue = PoliciesMaster.LEER_CUENTA,
                     RoleId = AdministradorId,
                 }




            );




        }
    }
}
