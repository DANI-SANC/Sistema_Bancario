using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_Bancario.Application.Interfaces.IRole;
using Sistema_Bancario.Dominio;
using Sistema_Bancario.Infrastructure.Persistence;

namespace Sistema_Bancario.Infrastructure.Respositories
{
    public class RoleRespository : IRoleRespository
    {

        private readonly DbContextSQL _context;

        public RoleRespository(DbContextSQL context)
        {
            _context = context;
        }

        public async Task AddRole(Role role)
        {
            await _context.Roles!.AddAsync(role);
        }
    }
}
