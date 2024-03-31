using api_assignment_solution.Models;

namespace api_assignment_solution.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product? GetById(int Id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == Id);
        }

        public void UpdateProduct(Product updProduct)
        {
            _context.Products.Update(updProduct);
            _context.SaveChanges();
        }
    }
}
