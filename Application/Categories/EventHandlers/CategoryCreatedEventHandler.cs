using Domain.Common;

namespace Application.Categories.EventHandlers;

public class CategoryCreatedEventHandler : INotificationHandler<>
{
    private Category entity;

    public CategoryCreatedEventHandler(Category entity)
    {
        this.entity = entity;
    }
}