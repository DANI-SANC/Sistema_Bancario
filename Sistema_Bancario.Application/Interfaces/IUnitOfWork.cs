using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_Bancario.Application.Interfaces.IRole;

namespace Sistema_Bancario.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        IRoleRespository? Roles { get; }



        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
