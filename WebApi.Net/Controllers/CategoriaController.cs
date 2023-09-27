using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controller;

[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    ICategoriaService service;

    public CategoriaController(ICategoriaService categoriaService)
    {
        service = categoriaService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(service.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Categoria categoria)
    {
        service.Save(categoria);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Categoria categoria)
    {
        service.Update(id,categoria);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        service.Delete(id);
        return Ok();
    } 
}