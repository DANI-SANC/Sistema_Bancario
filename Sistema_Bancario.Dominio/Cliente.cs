using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Bancario.Dominio
{
    public class Cliente : BaseEntity
    {
        public string? Nombres { get; set; }

        public string? Apellidos { get; set; }

        public int? Telefono { get; set; }

        public string? Email { get; set; }

        public string? Direccion {  get; set; }

        public DateOnly? FechaDeNacimiento { get; set; }

        public ICollection<CuentaBancaria> CuentaBancaria { get; set; } = new List<CuentaBancaria>();
    }
}
