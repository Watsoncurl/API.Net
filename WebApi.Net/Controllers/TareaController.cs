using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controller;

[Route("api/[controller]")]
public class TareaController : ControllerBase
{
    ITareasService service;

    public TareaController(ITareasService tareasService)
    {
        service = tareasService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(service.Get());
    }

    [HttpPost]
    public IActionResult Post(Tarea tarea)
    {
        service.Save(tarea);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Tarea tarea)
    {
        service.Update(id,tarea);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        service.Delete(id);
        return Ok();
    }
}