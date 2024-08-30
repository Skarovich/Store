namespace Store.Models
{
    public class ItemImage
    {
        public Guid Id { get; set; }
        public string Extenstion { get; set; }
        public virtual Item Item { get; set; }
    }
}
