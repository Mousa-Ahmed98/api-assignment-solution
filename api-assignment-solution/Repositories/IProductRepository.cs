using api_assignment_solution.Models;

namespace api_assignment_solution.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(int Id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
