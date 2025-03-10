using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Sistema_Bancario.Dominio
{
    public class Role : BaseEntity
    {
        public string? Nombre { get; set; }
        public string? Descripcion {  get; set; }
        public ICollection<AplicationUser> AplicationUsers { get; set; } = new List<AplicationUser>();
    }
}
