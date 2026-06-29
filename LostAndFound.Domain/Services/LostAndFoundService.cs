using LostAndFoundDomain.Models.DTOs;
using LostAndFoundDomain.Models.Domain;

namespace LostAndFoundDomain.Services;

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
        item.Status = StatusEnum.Available;
        item.DateFound = DateTime.UtcNow;
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
        if (item is null)
        {
            return false;
        }

        item.Status = newStatus;
        return true;
    }

    /// <summary>
    /// Creates a new found item and adds it to the repository. The item's status is set to "Available" and the date found is set to the current UTC time.
    /// </summary>
    /// <param name="item">The item to create.</param>
    public void CreateItem(FoundItemDTO item)
    {
        item.Status = StatusEnum.Available;
        item.DateFound = DateTime.UtcNow;
        _items.Add(item);
    }

    /// <summary>
    /// Claims an item by its ID. The item can only be claimed if its current status is "Available". If the item is successfully claimed, its status is updated to "Claimed".
    /// </summary>
    /// <param name="id">The ID of the item to claim.</param>
    /// <returns>True if the item was successfully claimed; otherwise, false.</returns>
    public bool ClaimItem(Guid id)
    {
        var item = _items.FirstOrDefault(i => i.Id == id);
        if (item is null || item.Status != StatusEnum.Available)
        {
            return false;
        }

        item.Status = StatusEnum.Claimed;
        return true;

    }
}