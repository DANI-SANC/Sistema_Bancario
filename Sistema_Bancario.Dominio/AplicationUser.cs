using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Sistema_Bancario.Dominio
{
    public class AplicationUser : IdentityUser
    {
      public Guid? RoleId { get; set; }
      public Role? Role {  get; set; } 
   
    }
}
