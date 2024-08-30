namespace Store.Models
{
    public class ItemFilterViewModel
    {
        public List<Item> Items { get; set; } = new List<Item>();
        public List<Guid> SelectedCategoryIds { get; set; } = new List<Guid>();
    }
}
