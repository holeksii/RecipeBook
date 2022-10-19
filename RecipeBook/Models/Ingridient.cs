using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Models;

class Ingridient
{
    [Key]
    public long Id { get; set; }
    
    [MinLength(3)]
    [Required]
    public string? Name { get; set; }
    
    [Range(0, 1000)]
    public int Quantity { get; set; }
    
    [RegularExpression(@"^(kg|g|l|ml|pcs)$")]
    public string? Measure { get; set; }
}
