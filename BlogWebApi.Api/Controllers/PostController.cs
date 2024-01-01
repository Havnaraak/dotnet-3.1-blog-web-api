using System.Threading.Tasks;
using BlogWebApi.Application.Requests.Posts.Commands.CreatePost;
using BlogWebApi.Application.Requests.Posts.Commands.DeletePost;
using BlogWebApi.Application.Requests.Posts.Commands.UpdatePost;
using BlogWebApi.Application.Requests.Posts.Queries.GetPosts;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BlogWebApi.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class PostController : ApiController
    {
        [HttpGet("")]
        [SwaggerOperation("Obtem todos posts cadastrados")]
        [SwaggerResponse(200, "Obtido com sucesso")]
        [SwaggerResponse(500, "Internal Server Error")]
        public async Task<IActionResult> GetPostsAsync()
        {
            var result = await Mediator.Send(new GetPostsQuery());
            return Ok(result);
        }

        [HttpPost("")]
        [SwaggerOperation("Cadastra um novo Post")]
        [SwaggerResponse(200, "Criado com sucesso")]
        [SwaggerResponse(500, "Internal Server Error")]
        public async Task<IActionResult> CreatePostAsync([FromBody] CreatePostCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{postId:long}")]
        [SwaggerOperation("Atualiza um post com base no identificador")]
        [SwaggerResponse(200, "Atualizado com sucesso")]
        [SwaggerResponse(500, "Internal Server Error")]
        public async Task<IActionResult> UpdatePostAsync([FromBody] UpdatePostCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{postId:long}")]
        [SwaggerOperation("Deleta um post com base no identificador")]
        [SwaggerResponse(200, "Excluido com sucesso")]
        [SwaggerResponse(500, "Internal Server Error")]
        public async Task<IActionResult> DeletePostAsync([FromBody] DeletePostCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
    }
}