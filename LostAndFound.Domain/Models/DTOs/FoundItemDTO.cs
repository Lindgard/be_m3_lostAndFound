using LostAndFound.Domain.Models.Domain;

namespace LostAndFound.Domain.Models.DTOs;

public class FoundItemDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public StatusEnum Status { get; set; }
    public string Description { get; set; } = string.Empty;
    public string FoundLocation { get; set; } = string.Empty;
}