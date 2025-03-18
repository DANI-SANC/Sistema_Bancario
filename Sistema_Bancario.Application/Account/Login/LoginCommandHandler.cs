using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sistema_Bancario.Application.Account.Register;
using Sistema_Bancario.Application.Result;
using Sistema_Bancario.Dominio;

namespace Sistema_Bancario.Application.Account.Login
{

    public record LoginCommandRequest(LoginRequestt loginRequest) : IRequest<Result<LoginProfile>>;
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, Result<LoginProfile>>
    {

        private readonly UserManager<AplicationUser> _userManager;

        public LoginCommandHandler(UserManager<AplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Result<LoginProfile>> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {

            var user = await _userManager.Users.FirstOrDefaultAsync(e => e.UserName == request.loginRequest.userName);


            if (user == null) return Result<LoginProfile>.Failure("Credenciales incorrectas");

            if(!await _userManager.CheckPasswordAsync(user, request.loginRequest.password!))
            {
                return Result<LoginProfile>.Failure("Credenciales incorrectas");
            }

            var profile = new LoginProfile
            {
                userName = user.UserName,
                login = "Credenciales correctas"
            };

            return Result<LoginProfile>.Success(profile);



            
        }
    }
}
