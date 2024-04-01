using api_assignment_solution.Models;
using api_assignment_solution.Models.ViewModels;

namespace api_assignment_solution.Services
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        CategortResVM? GetById(int Id);
        void AddCategory(Category Category);
        /*bool UpdateProduct(Product product);
        bool DeleteProduct(int Id);*/
    }
}
