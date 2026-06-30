using Microsoft.AspNetCore.Mvc;
using LostAndFoundDomain.Services;
using LostAndFoundDomain.Models.DTOs;
using LostAndFoundDomain.Models.Domain;
using LostAndFound.Api.Models;
namespace LostAndFound.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class LostAndFoundController : ControllerBase
{
    private readonly LostAndFoundService _service;

    public LostAndFoundController(LostAndFoundService service)
    {
        _service = service;
    }

    //* GET: /LostandFound
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<FoundItemResponseDTO>), StatusCodes.Status200OK)]
    public ActionResult<ApiResponse<IEnumerable<FoundItemResponseDTO>>> GetAllItems()
    {
        var items = _service.GetAllItems();
        return Ok(new ApiResponse<IEnumerable<FoundItemResponseDTO>>(items, "Items retrieved successfully.", StatusCodes.Status200OK));
    }

    //* POST: /LostAndFound
    [HttpPost]
    [ProducesResponseType(typeof(FoundItemResponseDTO), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
    public ActionResult<ApiResponse<FoundItemResponseDTO>> AddItem([FromBody] CreateFoundItemDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new ApiResponse<object>(null, "Invalid input data.", StatusCodes.Status400BadRequest));
        }

        var createdItem = _service.AddItem(dto);
        return CreatedAtAction(nameof(GetAllItems), new ApiResponse<FoundItemResponseDTO>(createdItem, "Item created successfully.", StatusCodes.Status201Created));
    }

    //* PATCH: /lostandfound/{id}/status
    [HttpPatch("{id:guid}/status")]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    public ActionResult<ApiResponse<object>> UpdateItemStatus(Guid id, [FromBody] StatusEnum newStatus)
    {
        var updated = _service.UpdateItemStatus(id, newStatus);
        if (!updated)
        {
            return NotFound(new ApiResponse<object>(null, "Item not found.", StatusCodes.Status404NotFound));
        }

        return Ok(new ApiResponse<object>(null, "Item status updated successfully.", StatusCodes.Status200OK));
    }

    //* PATCH: /lostandfound/{id}/claim
    [HttpPatch("{id:guid}/claim")]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status409Conflict)]
    public ActionResult<ApiResponse<object>> ClaimItem(Guid id)
    {
        var item = _service.GetAllItems().FirstOrDefault(i => i.Id == id);

        if (item == null)
        {
            return NotFound(new ApiResponse<object>(null, "Item not found.", StatusCodes.Status404NotFound));
        }

        var claimed = _service.ClaimItem(id);
        if (!claimed)
        {
            return Conflict(new ApiResponse<object>(null, $"Item with id {id} is already claimed.", StatusCodes.Status409Conflict));
        }

        return Ok(new ApiResponse<object>(null, "Item claimed successfully.", StatusCodes.Status200OK));
    }

    [HttpGet("items")]
    [ProducesResponseType(typeof(IEnumerable<FoundItemResponseDTO>), StatusCodes.Status200OK)]
    public ActionResult<ApiResponse<IEnumerable<FoundItemResponseDTO>>> GetItems([FromQuery] StatusEnum? status = null, [FromQuery] string? category = null)
    {
        var items = _service.GetItems(status, category);

        var message = (status, category) switch
        {
            (not null, not null) => $"Items with status '{status}' and category '{category}' retrieved successfully.",
            (not null, null) => $"Items with status '{status}' retrieved successfully.",
            (null, not null) => $"Items with category '{category}' retrieved successfully.",
            _ => "All items retrieved successfully."
        };

        return Ok(new ApiResponse<IEnumerable<FoundItemResponseDTO>>(items, message, StatusCodes.Status200OK));
    }
}
