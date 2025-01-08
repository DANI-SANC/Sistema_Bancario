using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Bancario.Dominio
{
    public class CuentaBancaria : BaseEntity
    {
        public string? NumeroDeCuenta {  get; set; }
        public decimal? Saldo { get; set; }
        
        public Guid? ClienteId {  get; set; }

        public Cliente? Cliente { get; set; }

        public ICollection<Transaccion> Transaccion { get; set; } = new List<Transaccion>();


    }
}
