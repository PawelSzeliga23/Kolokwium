
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers;
[ApiController]
[Route("/api/patient")]
public class PatientController : ControllerBase
{
    private readonly IPatientService _service;

    public PatientController(IPatientService service)
    {
        _service = service;
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeletePatient([FromQuery] int id)
    {
        /*var rows = _service.deletePatient(id);*/
        return Ok();
    }
}