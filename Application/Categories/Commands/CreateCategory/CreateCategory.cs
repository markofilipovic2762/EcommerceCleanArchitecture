
using Application.Categories.EventHandlers;
using Application.Common.Interfaces;

namespace Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<int>
{
    public string Name { get; init; } = string.Empty;
}

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = new Category
        {
            Name = request.Name
        };

        entity.AddDomainEvent(new CategoryCreatedEventHandler(entity));

        _context.Categories.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}


