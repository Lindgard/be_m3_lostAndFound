using LostAndFound;

namespace LostAndFound.Tests;

public class LostAndFoundTests
{
    [Fact]
    public void GetAllItems_ReturnsAllItems()
    {
        //* Arrange
        var repository = new LostAndFoundRepository();
        var item1 = new LostItem { Id = 1, Name = "wallet", Description = "black leather wallet", DateLost = DateTime.Now.AddDays(-1) };
        var item2 = new LostItem { Id = 2, Name = "keys", Description = "set of car keys", DateLost = DateTime.Now.AddDays(-2) };
        repository.AddItem(item1);
        repository.AddItem(item2);

        //* Act
        var items = repository.GetAllItems();

        //* Assert
        Assert.Equal(2, items.Count);
        Assert.Contains(items, i => i.Id == item1.Id && i.Name == item1.Name && i.Description == item1.Description && i.DateLost == item1.DateLost);
        Assert.Contains(items, i => i.Id == item2.Id && i.Name == item2.Name && i.Description == item2.Description && i.DateLost == item2.DateLost);
    }
}
