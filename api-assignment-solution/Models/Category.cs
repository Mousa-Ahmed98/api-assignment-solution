namespace api_assignment_solution.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product>? Products { get; set; }
    }
}
