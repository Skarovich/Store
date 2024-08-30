namespace Store.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IReadOnlyCollection<Item> Items { get; set; }
    }
}
