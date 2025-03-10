using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Bancario.Dominio
{
    public class Transaccion : BaseEntity
    {
        public decimal? Monto { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaTransaccion {  get; set; }

        public Guid? CuentaBancariaId {  get; set; }

        public CuentaBancaria? CuentaBancaria { get; set; }

        public Guid? TipoTransaccionId { get; set; }
        
        public TipoTransaccion? TipoTransaccion { get; set; }
    }
}
