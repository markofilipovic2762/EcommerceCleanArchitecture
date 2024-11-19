namespace Application.Common.Interfaces.Repositories;

public interface ICategoryRepository
{
    Task<Category?> GetCategoryByIdAsync(int id);
    Task<List<Category>> GetAllCategoriesAsync();
    Task AddCategoryAsync(Category category);
    Task UpdateCategoryAsync(Category category);
    Task DeleteCategoryAsync(Category category);
}
