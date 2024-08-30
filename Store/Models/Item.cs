using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class Item
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Summary { get; set; }

        [Required]
        public decimal Price { get; set; }

        public Guid? ImageId { get; set; }

        public virtual ItemImage Image { get; set; }
        [Required(ErrorMessage = "Please select at least one category.")]
        public List<Guid> CategoryIds { get; set; } = new List<Guid>();

        public ICollection<Category> Categories { get; set; } = new List<Category>();
    }

}
