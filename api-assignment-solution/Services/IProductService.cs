using api_assignment_solution.Models;

namespace api_assignment_solution.Services
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(int Id);
        void AddProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int Id);
    }
}
