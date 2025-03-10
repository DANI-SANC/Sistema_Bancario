using MediatR;
using Microsoft.AspNetCore.Mvc;

using Sistema_Bancario.Application.RoleCommand.Create;

namespace Sistema_Bancario.Presentacion.Controllers
{

    [ApiController]
    [Route("api/role")]
    public class RoleController : Controller
    {

   

        private readonly ISender _sender;

        public RoleController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody] CreateRoleRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateRolCommandRequest(request);

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result.Error);


        }
    }
}