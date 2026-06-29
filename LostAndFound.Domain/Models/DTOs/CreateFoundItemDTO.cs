using System.ComponentModel.DataAnnotations;

namespace LostAndFoundDomain.Models.DTOs;

public class CreateFoundItemDTO
{
    [Required]
    [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
    public string Title { get; set; } = string.Empty;

    [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string Description { get; set; } = string.Empty;

    [Required]
    [MaxLength(100, ErrorMessage = "Found location cannot exceed 100 characters.")]
    public string FoundLocation { get; set; } = string.Empty;

    [MaxLength(50, ErrorMessage = "Category cannot exceed 50 characters.")]
    public string Category { get; set; } = string.Empty;
}