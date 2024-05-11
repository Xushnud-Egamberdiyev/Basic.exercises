using MediatR;
using Post.Domain.Entity;
using System.Net;

namespace Post.Application.UseCases.Commands;

public class CreatePostModelCommand : IRequest<ResponseModel>
{
    public string Title { get; set; }
    public string Description { get; set; }
}
