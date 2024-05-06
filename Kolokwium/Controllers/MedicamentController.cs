using Kolokwium.Exceptions;
using Kolokwium.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers;
[ApiController]
[Route("/api/medicament")]
public class MedicamentController : ControllerBase
{
    private readonly IMedicamentService _service;

    public MedicamentController(IMedicamentService service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetMedicamentById([FromQuery] int id)
    {
        try
        {
            var medicament = _service.GetMedicamentById(id);
            return Ok(medicament);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}