using System.ComponentModel.DataAnnotations;

public class Comment
{
    [Key]
    public long Id { get; set; }
    
    [Required]
    [MinLength(3)]
    public string? Text { get; set; }
    
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime Time { get; set; }
}
