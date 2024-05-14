using System.ComponentModel.DataAnnotations;

namespace  MextFullStack.Domain.Dtos
{
    public sealed class ProductEditDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        public string? Description { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
    }
}
