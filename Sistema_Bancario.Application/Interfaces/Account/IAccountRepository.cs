using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_Bancario.Dominio;

namespace Sistema_Bancario.Application.Interfaces.Account
{
    public interface IAccountRepository
    {
        Task AddAccount(AplicationUser aplicationUser);

        Task<AplicationUser?> GetAccount(AplicationUser aplicationUser);



    }
}
