using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Bancario.Application.RoleCommand.Create
{
    public class CreateRoleRequest
    {
        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }
    }
}
