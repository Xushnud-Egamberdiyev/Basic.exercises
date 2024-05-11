using MediatR;
using Post.Domain.Entity;

namespace Post.Application.UseCases.Commands;

public class DeletePostModelCommand : IRequest<ResponseModel>
{
    public int id { get; set; }
}
