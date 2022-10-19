using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Models;

public class Like
{
    [Key]
    public long Id { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime Time { get; set; }
}
