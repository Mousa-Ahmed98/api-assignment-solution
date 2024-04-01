using api_assignment_solution.Models;
using api_assignment_solution.Models.ViewModels;

namespace api_assignment_solution.Services
{
    public interface IProductService
    {
        List<Product> GetAll();
        ProductRetVM GetById(int Id);
        void AddProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int Id);
    }
}
