using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Sistema_Bancario.Application.Account.Login;
using Sistema_Bancario.Application.Account.Register;


namespace Sistema_Bancario.Presentacion.Controllers
{

    [ApiController]
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly ISender _sender;

        public AccountController(ISender sender)
        {
            _sender = sender;
        }


        [HttpPost("register")]
        public async Task<IActionResult> RegisterAccount([FromBody] CreateRegisterRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateRegisterCommandRequest(request);

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result.Error);

        }
        //comentario
        [HttpPost("login")] 
        public async Task<IActionResult> LoginAccount([FromBody] LoginRequestt request, CancellationToken cancellationToken)
        {
            var command = new LoginCommandRequest(request);
            var result = await _sender.Send(command, cancellationToken);


            //--
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Error); 
            }
        }


    }
}
