using api_assignment_solution.Models;
using api_assignment_solution.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace api_assignment_solution.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddCategory(Category Category)
        {
            _context.Categories.Add(Category);
            _context.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public CategortResVM? GetById(int Id)
        {
            Category? category = _context.Categories
                .Where(c => c.Id == Id)
                .Include(c => c.Products)
                .FirstOrDefault();

            CategortResVM? categortResVM = new CategortResVM() 
            {
                Id = category.Id,
                Name = category.Name,
                Products = category.Products.Select(p => p.Name).ToList(),
            };

            return categortResVM;
        }
    }
}
