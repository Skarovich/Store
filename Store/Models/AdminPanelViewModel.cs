namespace Store.Models
{
    public class AdminPanelViewModel
    {
        public List<Item> Items { get; set; } = new List<Item>();
        public List<Category> Categories { get; set; } = new List<Category>();
        public string ActiveTab { get; set; } = "Items";
    }

}
