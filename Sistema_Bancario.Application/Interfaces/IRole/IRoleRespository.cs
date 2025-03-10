using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_Bancario.Dominio;


namespace Sistema_Bancario.Application.Interfaces.IRole
{
    public interface IRoleRespository
    {
        Task AddRole(Role role);
    }
}
