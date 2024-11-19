
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Data.Repositories;

public class CategoryRepository(IApplicationDbContext context) : ICategoryRepository
{
    public async Task AddCategoryAsync(Category category)
    {
       await context.Categories.AddAsync(category);
    }

    public Task DeleteCategoryAsync(Category category)
    {
        throw new NotImplementedException();
    }

    public Task<List<Category>> GetAllCategoriesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Category?> GetCategoryByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCategoryAsync(Category category)
    {
        throw new NotImplementedException();
    }
}
