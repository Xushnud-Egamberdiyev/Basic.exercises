using MediatR;
using Post.Domain.Entity;

namespace Post.Application.UseCases.Commands;

public class UpdatePostModelCommamd : IRequest<ResponseModel>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }


}

