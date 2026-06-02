using LostAndFound.Domain.Models.DTOs;
using LostAndFound.Domain.Models.Domain;

namespace LostAndFound.Domain.Services;

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

    /// <summary>
    /// Updates the status of an item based on its ID.
    /// </summary>
    /// <param name="id">The ID of the item to update.</param>
    /// <param name="newStatus">The new status to set.</param>
    /// <returns>True if the item was found and updated; otherwise, false.</returns>
    public bool UpdateItemStatus(Guid id, StatusEnum newStatus)
    {
        var item = _items.FirstOrDefault(i => i.Id == id);
        if (item is null) return false;

        item.Status = newStatus;
        return true;
    }
}