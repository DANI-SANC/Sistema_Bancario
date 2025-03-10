using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sistema_Bancario.Application.Result;
using Sistema_Bancario.Dominio;

namespace Sistema_Bancario.Application.Account.Register
{
    public record CreateRegisterCommandRequest(CreateRegisterRequest CreateRegisterRequest) : IRequest<Result<Profile>>;

    public class CreateRegisterHandler : IRequestHandler<CreateRegisterCommandRequest, Result<Profile>>
    {
        private readonly UserManager<AplicationUser> _userManager;

        public CreateRegisterHandler(UserManager<AplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Result<Profile>> Handle(CreateRegisterCommandRequest request, CancellationToken cancellationToken)
        {
            if (await _userManager.Users.AnyAsync(e => e.Email == request.CreateRegisterRequest.Email))
            {
                return Result<Profile>.Failure("El email ya está registrado por otro usuario");
            }

            if (await _userManager.Users.AnyAsync(e => e.UserName == request.CreateRegisterRequest.UserName))
            {
                return Result<Profile>.Failure("El nombre de usuario ya está registrado por otro usuario");
            }


          

            var user = new AplicationUser
            {
                UserName = request.CreateRegisterRequest.UserName,
                Email = request.CreateRegisterRequest.Email,
    
                RoleId = request.CreateRegisterRequest.RoleId
            };

            var profile = new Profile
            {
                userName = user.UserName
            };

            var resultado = await _userManager.CreateAsync(user, request.CreateRegisterRequest.Password!);


            if (resultado.Succeeded)
            {
                return Result<Profile>.Success(profile);
            }
            else
            {
                Console.WriteLine(resultado);
                return Result<Profile>.Failure("No se pudo registrar el usuario");
            }
        }
    }
}
