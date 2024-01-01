 using BlogWebApi.Application.Authors.Commands.CreateAuthor;
using BlogWebApi.Application.Authors.Commands.DeleteAuthor;
using BlogWebApi.Application.Authors.Commands.UpdateAuthor;
using BlogWebApi.Application.Authors.Queries.GetAuthors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogWebApi.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AuthorController : ApiController
    {
        [HttpGet("")]
        public async Task<IActionResult> GetAuthorsAsync()
        {
            var result = await Mediator.Send(new GetAuthorsQuery());
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateAuthorAsync([FromBody] CreateAuthorCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{authorId:long}")]
        public async Task<IActionResult> UpdateAuthorAsync([FromRoute] long authorId, [FromBody] UpdateAuthorCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{authorId:long}")]
        public async Task<IActionResult> DeleteAuthorAsync([FromRoute] long authorId, [FromBody] DeleteAuthorCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
    }
}
