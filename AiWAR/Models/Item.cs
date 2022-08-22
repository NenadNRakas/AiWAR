// Define an object
using System.ComponentModel.DataAnnotations;

namespace AiWAR.Models
{
    public enum ItemSize { Small, Medium, Large }
    public class Item
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public ItemSize Size { get; set; }
        public bool IsOnStock { get; set; }

        [Range(0.01, 9999.99)]
        public decimal Price { get; set; }
    }
}