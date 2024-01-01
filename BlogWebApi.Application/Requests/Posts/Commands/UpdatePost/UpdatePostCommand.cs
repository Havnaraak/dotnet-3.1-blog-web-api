using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BlogWebApi.Application.Interfaces;
using BlogWebApi.Domain.Entities;
using BlogWebApi.Domain.Models;
using BlogWebApi.Infrastructure.CrossCutting.Interfaces;
using MediatR;

namespace BlogWebApi.Application.Requests.Posts.Commands.UpdatePost
{
    public class UpdatePostCommand : IRequest<UpdatePostCommandResponse>, IMapTo<PostModel>
    {
        public long Id { get; set; }
        
        public string Title { get; set; }
        
        public string Content { get; set; }
        
        public long AuthorId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePostCommand, PostModel>()
                .ForMember(d => d.Author, opt => opt.Ignore());
        }
    }

    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, UpdatePostCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<UpdatePostCommandResponse> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var postRepository = _unitOfWork.GetRepository<Post>();
            var authorRepository = _unitOfWork.GetRepository<Author>();

            var author = authorRepository.FindBy(a => a.Id == request.AuthorId).FirstOrDefault();
            var post = postRepository.FindBy(p => p.Id == request.Id).FirstOrDefault();
            
            var postModel = _mapper.Map<PostModel>(request);
            postModel.Author = author;
            
            post?.UpdatePost(postModel);
            
            postRepository.Update(post);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _mapper.Map<UpdatePostCommandResponse>(post);
        }
    }
}