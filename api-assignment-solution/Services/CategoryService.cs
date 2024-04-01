using api_assignment_solution.Models;
using api_assignment_solution.Models.ViewModels;
using api_assignment_solution.Repositories;

namespace api_assignment_solution.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public void AddCategory(Category Category)
        {
            categoryRepository.AddCategory(Category);
        }

        public List<Category> GetAll()
        {
            return categoryRepository.GetAll();
        }

        public CategortResVM? GetById(int Id)
        {
            return categoryRepository.GetById(Id);
        }
    }
}
