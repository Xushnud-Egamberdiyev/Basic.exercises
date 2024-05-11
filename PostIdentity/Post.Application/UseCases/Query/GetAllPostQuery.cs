using MediatR;
using Post.Domain.Entity;

namespace Post.Application.UseCases.Query;

public class GetAllPostQuery : IRequest<IEnumerable<PostModel>>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
