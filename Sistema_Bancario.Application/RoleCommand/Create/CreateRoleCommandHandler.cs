using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Sistema_Bancario.Application.Interfaces;
using Sistema_Bancario.Application.Result;
using Sistema_Bancario.Dominio;

namespace Sistema_Bancario.Application.RoleCommand.Create
{
    public record CreateRolCommandRequest  (CreateRoleRequest createRoleRequest): IRequest<Result<Guid>>
    {
        public class CreateRoleCommandHandler : IRequestHandler<CreateRolCommandRequest, Result<Guid>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public CreateRoleCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<Guid>> Handle(CreateRolCommandRequest request, CancellationToken cancellationToken)
            {
                var rol = new Role
                {
                    Nombre = request.createRoleRequest.Nombre,
                    Descripcion = request.createRoleRequest.Descripcion,
                };

                await _unitOfWork.Roles!.AddRole(rol);

                var resultado = await _unitOfWork.SaveChangesAsync(cancellationToken) > 0;

                return resultado ? Result<Guid>.Success(rol.Id!.Value) : Result<Guid>.Failure("No se puede insertar un rol");
            }
        }
    }
}
