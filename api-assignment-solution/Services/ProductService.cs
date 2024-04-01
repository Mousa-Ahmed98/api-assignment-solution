using api_assignment_solution.Models;
using api_assignment_solution.Models.ViewModels;
using api_assignment_solution.Repositories;

namespace api_assignment_solution.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }

        public bool DeleteProduct(int Id)
        {
            Product? product = _productRepository.GetById(Id);
            if (product != null)
            {
                _productRepository.DeleteProduct(product);
                return true;
            }
            return false;
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public ProductRetVM GetById(int Id)
        {
            Product Product = _productRepository.GetById(Id);
            ProductRetVM ProductRetVM = new ProductRetVM() 
            { 
                Name = Product.Name,
                Description = Product.Description,
                Price = Product.Price,
                Category = Product?.Category?.Name,
            };

            return ProductRetVM;
        }

        public bool UpdateProduct(Product updProduct)
        {
            Product? product = _productRepository.GetById(updProduct.Id);
            if (product == null)
            {
                return false;
            }
            product.Name = updProduct.Name;
            product.Price = updProduct.Price;
            product.Description = updProduct.Description;
            product.CategoryId = updProduct.CategoryId;
            _productRepository.UpdateProduct(product);
            return true;
        }
    }
}
