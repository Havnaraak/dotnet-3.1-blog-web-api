using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using BlogWebApi.Application.Requests.Authors.Commands.CreateAuthor;
using BlogWebApi.Application.Requests.Authors.Commands.DeleteAuthor;
using BlogWebApi.Application.Requests.Authors.Commands.UpdateAuthor;
using BlogWebApi.Application.Requests.Authors.Queries.GetAuthors;

namespace BlogWebApi.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AuthorController : ApiController
    {
        [HttpGet("")]
        [SwaggerOperation("Obtem todos autores cadastrados")]
        [SwaggerResponse(200, "Obtido com sucesso")]
        [SwaggerResponse(500, "Internal Server Error")]
        public async Task<IActionResult> GetAuthorsAsync()
        {
            var result = await Mediator.Send(new GetAuthorsQuery());
            return Ok(result);
        }

        [HttpPost("")]
        [SwaggerOperation("Cadastra um novo autor")]
        [SwaggerResponse(200, "Criado com sucesso")]
        [SwaggerResponse(500, "Internal Server Error")]
        public async Task<IActionResult> CreateAuthorAsync([FromBody] CreateAuthorCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{authorId:long}")]
        [SwaggerOperation("Atualiza um autor com base no identificador")]
        [SwaggerResponse(200, "Atualizado com sucesso")]
        [SwaggerResponse(500, "Internal Server Error")]
        public async Task<IActionResult> UpdateAuthorAsync([FromBody] UpdateAuthorCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{authorId:long}")]
        [SwaggerOperation("Deleta um autor com base no identificador")]
        [SwaggerResponse(200, "Excluido com sucesso")]
        [SwaggerResponse(500, "Internal Server Error")]
        public async Task<IActionResult> DeleteAuthorAsync([FromBody] DeleteAuthorCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
    }
}
