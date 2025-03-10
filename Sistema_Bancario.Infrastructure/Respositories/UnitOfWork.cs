using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_Bancario.Application.Interfaces;
using Sistema_Bancario.Application.Interfaces.IRole;
using Sistema_Bancario.Infrastructure.Persistence;

namespace Sistema_Bancario.Infrastructure.Respositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DbContextSQL _context;

        public UnitOfWork(DbContextSQL context)
        {
            _context = context;
            Roles = new RoleRespository(_context);
        }

        public IRoleRespository? Roles { get; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
           return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
