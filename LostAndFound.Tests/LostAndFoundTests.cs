using LostAndFound.Domain.Services;
using LostAndFound.Domain.Models.DTOs;
using LostAndFound.Domain.Models.Domain;

namespace LostAndFound.Tests;

public class LostAndFoundTests
{
    [Fact]
    public void GetAllItems_ReturnsAllItems()
    {
        //* Arrange
        var service = new LostAndFound.Domain.Services.LostAndFoundService();
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

        service.AddItem(item1);
        service.AddItem(item2);

        //* Act
        service.GetAllItems();

        //* Assert
        var items = service.GetAllItems();
        Assert.NotNull(items);
        Assert.Contains(items, i => i.Id == item1.Id && i.Title == item1.Title && i.Status == item1.Status && i.Description == item1.Description && i.FoundLocation == item1.FoundLocation);
        Assert.Contains(items, i => i.Id == item2.Id && i.Title == item2.Title && i.Status == item2.Status && i.Description == item2.Description && i.FoundLocation == item2.FoundLocation);
    }

    [Fact]
    public void AddItem_AddsNewItem()
    {
        //* Arrange
        var service = new LostAndFound.Domain.Services.LostAndFoundService();
        var newItem = new FoundItemDTO
        {
            Id = Guid.NewGuid(),
            Title = "Backpack",
            Status = StatusEnum.Available,
            Description = "Blue backpack found in the gym.",
            FoundLocation = "Gym"
        };

        //* Act
        service.AddItem(newItem);

        //* Assert
        var items = service.GetAllItems();
        Assert.Contains(items, i =>
            i.Id == newItem.Id && i.Title == newItem.Title && i.Status == newItem.Status && i.Description == newItem.Description && i.FoundLocation == newItem.FoundLocation);
    }

    [Theory]
    [InlineData(StatusEnum.Available)]
    [InlineData(StatusEnum.Claimed)]
    [InlineData(StatusEnum.Returned)]
    public void UpdateItemStatus_WhenItemExists_ChangesStatus(StatusEnum newStatus)
    {
        //* Arrange
        var service = new LostAndFound.Domain.Services.LostAndFoundService();
        var item = new FoundItemDTO
        {
            Id = Guid.NewGuid(),
            Title = "Sunglasses",
            Status = StatusEnum.Available,
            Description = "Ray-Ban sunglasses found in the cafeteria.",
            FoundLocation = "Cafeteria"
        };

        service.AddItem(item);

        //* Act
        var updatedItem = service.UpdateItemStatus(item.Id, newStatus);

        //* Assert
        Assert.True(updatedItem);
        var storedItem = service.GetAllItems().Single(i => i.Id == item.Id);
        Assert.Equal(newStatus, storedItem.Status);
    }

    [Fact]
    public void UpdateItemStatus_WhenItemDoesNotExist_ReturnsFalse()
    {
        //* Arrange
        var service = new LostAndFound.Domain.Services.LostAndFoundService();

        //* Act
        var updated = service.UpdateItemStatus(Guid.NewGuid(), StatusEnum.Claimed);

        //* Assert
        Assert.False(updated);
    }
}
