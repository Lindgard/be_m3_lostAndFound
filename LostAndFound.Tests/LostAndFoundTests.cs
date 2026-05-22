using LostAndFoundService.Services;
using LostAndFoundService.Models.DTOs;
using LostAndFoundService.Models.Domain;

namespace LostAndFound.Tests;

public class LostAndFoundTests
{
    [Fact]
    public void GetAllItems_ReturnsAllItems()
    {
        //* Arrange
        var service = new LostAndFoundService();
        var item1 = new FoundItemDTO
        {
            Id = Guid.NewGuid(),
            Title = "Wallet",
            Status = StatusEnum.Available,
            Description = "Black leather wallet found in classroom 101.",
            FoundLocation = "Classroom 101"
        };
        var item2 = new FoundItemDTO
        {
            Id = Guid.NewGuid(),
            Title = "Phone",
            Status = StatusEnum.Available,
            Description = "iPhone found in the school library.",
            FoundLocation = "School Library"
        };

        //* Act
        service.GetAllItems();

        //* Assert
    }
}
