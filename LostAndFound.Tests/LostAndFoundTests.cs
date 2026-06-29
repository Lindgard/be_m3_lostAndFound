using LostAndFoundDomain.Services;
using LostAndFoundDomain.Models.DTOs;
using LostAndFoundDomain.Models.Domain;
namespace LostAndFound.Tests;

public class LostAndFoundTests
{
    [Fact]
    public void GetAllItems_ReturnsAllItems()
    {
        //* Arrange
        var service = new LostAndFoundDomain.Services.LostAndFoundService();
        var item1 = new CreateFoundItemDTO
        {
            Title = "Wallet",
            Description = "Black leather wallet found in classroom 101.",
            FoundLocation = "Classroom 101"
        };

        var item2 = new CreateFoundItemDTO
        {
            Title = "Phone",
            Description = "iPhone found in the school library.",
            FoundLocation = "School Library"
        };

        service.AddItem(item1);
        service.AddItem(item2);

        //* Act
        var items = service.GetAllItems();

        //* Assert
        Assert.NotNull(items);
        Assert.Contains(items, i => i.Title == item1.Title && i.Description == item1.Description && i.FoundLocation == item1.FoundLocation);
        Assert.Contains(items, i => i.Title == item2.Title && i.Description == item2.Description && i.FoundLocation == item2.FoundLocation);
    }

    [Fact]
    public void AddItem_AddsNewItem()
    {
        //* Arrange
        var service = new LostAndFoundDomain.Services.LostAndFoundService();
        var newItem = new CreateFoundItemDTO
        {
            Title = "Backpack",
            Description = "Blue backpack found in the gym.",
            FoundLocation = "Gym"
        };

        //* Act
        service.AddItem(newItem);

        //* Assert
        var items = service.GetAllItems();
        Assert.Contains(items, i =>
            i.Title == newItem.Title && i.Description == newItem.Description && i.FoundLocation == newItem.FoundLocation);
    }

    [Theory]
    [InlineData(StatusEnum.Available)]
    [InlineData(StatusEnum.Claimed)]
    [InlineData(StatusEnum.Returned)]
    public void UpdateItemStatus_WhenItemExists_ChangesStatus(StatusEnum newStatus)
    {
        //* Arrange
        var service = new LostAndFoundDomain.Services.LostAndFoundService();
        var item = service.AddItem(new CreateFoundItemDTO
        {
            Title = "Sunglasses",
            Description = "Ray-Ban sunglasses found in the cafeteria.",
            FoundLocation = "Cafeteria"
        });

        //* Act
        var updatedItem = service.UpdateItemStatus(item.Id, newStatus);

        //* Assert
        Assert.True(updatedItem);
        Assert.Equal(newStatus, service.GetAllItems().Single(i => i.Id == item.Id).Status);
    }

    [Fact]
    public void UpdateItemStatus_WhenItemDoesNotExist_ReturnsFalse()
    {
        //* Arrange
        var service = new LostAndFoundDomain.Services.LostAndFoundService();

        //* Act
        var updated = service.UpdateItemStatus(Guid.NewGuid(), StatusEnum.Claimed);

        //* Assert
        Assert.False(updated);
    }

    [Fact]
    public void CreateItem_SetsDefaultStatusAndTimestamp()
    {
        //* Arrange
        var service = new LostAndFoundDomain.Services.LostAndFoundService();
        var before = DateTime.UtcNow;

        var dto = new CreateFoundItemDTO
        {
            Title = "Keys",
            Description = "Set of car keys found in parking lot",
            FoundLocation = "Parking Lot"
        };

        service.AddItem(dto);

        //* Act
        var saved = service.AddItem(dto);

        //* Assert
        Assert.Equal(StatusEnum.Available, saved.Status);
        Assert.True(saved.DateFound >= before && saved.DateFound <= DateTime.UtcNow);
    }

    [Fact]
    public void ClaimItem_WorksOnlyFromAvailableStatus()
    {
        //* Arrange
        var service = new LostAndFoundDomain.Services.LostAndFoundService();
        var item = service.AddItem(new CreateFoundItemDTO
        {
            Title = "Watch",
            FoundLocation = "Locker Room",
            Description = "Silver wristwatch found in locker room"
        });

        //* Act
        var firstClaim = service.ClaimItem(item.Id);
        var secondClaim = service.ClaimItem(item.Id);

        //* Assert
        Assert.True(firstClaim);
        Assert.False(secondClaim);
        Assert.Equal(StatusEnum.Claimed, service.GetAllItems().Single(i => i.Id == item.Id).Status);
    }
}
