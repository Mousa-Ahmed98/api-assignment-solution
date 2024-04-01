using api_assignment_solution.Models;
using api_assignment_solution.Models.ViewModels;

namespace api_assignment_solution.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        CategortResVM? GetById(int Id);
        void AddCategory(Category Category);
        //void UpdateProduct(Product product);
        //void DeleteProduct(Product product);
    }
}
