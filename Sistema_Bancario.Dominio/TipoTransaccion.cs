using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Bancario.Dominio
{
    public class TipoTransaccion : BaseEntity
    {
        public string? Nombre { get; set; }

        public string?  Descripcion { get; set; }

        public ICollection<Transaccion> Transaccion { get; set; } = new List<Transaccion>();
    }
}
