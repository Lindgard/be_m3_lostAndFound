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
        var service = new LostAndFoundService.Services.LostAndFoundService();
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
        var items = service.GetAllItems();
        Assert.NotNull(items);
        Assert.Contains(items, i => i.Id == item1.Id && i.Title == item1.Title && i.Status == item1.Status && i.Description == item1.Description && i.FoundLocation == item1.FoundLocation);
    }
}
