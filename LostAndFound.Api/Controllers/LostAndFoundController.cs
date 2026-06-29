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

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<FoundItemResponseDTO>), StatusCodes.Status200OK)]
    public ActionResult<ApiResponse<IEnumerable<FoundItemResponseDTO>>> GetAllItems()
    {
        var items = _service.GetAllItems();
        return Ok(new ApiResponse<IEnumerable<FoundItemResponseDTO>>(items, "Items retrieved successfully.", StatusCodes.Status200OK));
    }
}
