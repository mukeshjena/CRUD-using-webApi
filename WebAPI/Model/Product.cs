using System.ComponentModel.DataAnnotations;

namespace WebAPI.Model
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [Range(10, 10000, ErrorMessage ="Price is in between 10 to 10000 only.")]
        public double Price { get; set; }
    }
}
