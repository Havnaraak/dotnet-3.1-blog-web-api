using BlogWebApi.Application.Authors.Commands.CreateAuthor;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogWebApi.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AuthorController : ApiController
    {
        [HttpPost("")]
        public async Task<IActionResult> CreateAuthorAsync([FromBody] CreateAuthorCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
