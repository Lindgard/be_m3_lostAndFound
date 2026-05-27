using LostAndFoundService.Models.DTOs;

namespace LostAndFoundService.Services;

public class LostAndFoundService
{
    /// <summary>
    /// In-memory list to store found items. This would be replaced with a database or other persistent storage.
    /// </summary>
    private readonly List<FoundItemDTO> _items = new List<FoundItemDTO>();

    /// <summary>
    /// Initializes a new instance of the <see cref="LostAndFoundService"/> class.
    /// </summary>
    public LostAndFoundService()
    {
    }

    /// <summary>
    /// Gets all items from the repository.
    /// </summary>
    /// <returns>A list of all found items.</returns>
    public List<FoundItemDTO> GetAllItems()
    {
        return _items;
    }

    /// <summary>
    /// Adds a new item to the repository.
    /// </summary>
    /// <param name="item">The item to add.</param>
    public void AddItem(FoundItemDTO item)
    {
        _items.Add(item);
    }

}