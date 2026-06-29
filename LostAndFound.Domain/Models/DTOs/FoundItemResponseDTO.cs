using LostAndFoundDomain.Models.Domain;

namespace LostAndFoundDomain.Models.DTOs;

public class FoundItemResponseDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string FoundLocation { get; set; } = string.Empty;
    public DateTime DateFound { get; set; }
    public StatusEnum Status { get; set; }
    public string? ClaimedBy { get; set; } = string.Empty;
    public DateTime? DateClaimedAt { get; set; }
    public DateTime? DateReturnedAt { get; set; }
}