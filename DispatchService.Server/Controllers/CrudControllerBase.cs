using DispatchService.Application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DispatchService.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public abstract class CrudControllerBase<TDto, TCreateUpdateDto, TKey>(ICrudService<TDto, TCreateUpdateDto, TKey> crudService) : ControllerBase
    where TDto : class
    where TCreateUpdateDto : class
    where TKey : struct
{
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public IActionResult Create(TCreateUpdateDto newDto)
    {
        try
        {
            var res = crudService.Create(newDto);
            return res ? Ok() : StatusCode(400);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public IActionResult Edit(TKey id, TCreateUpdateDto newDto)
    {
        try
        {
            var res = crudService.Update(id, newDto);
            return res ? Ok() : StatusCode(400);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public IActionResult Delete(TKey id)
    {
        try
        {
            var res = crudService.Delete(id);
            return res ? Ok() : NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public ActionResult<IList<TDto>> GetAll()
    {
        try
        {
            var res = crudService.GetList();
            return Ok(res);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public ActionResult<TDto> Get(TKey id)
    {
        try
        {
            var res = crudService.GetById(id);
            return res != null ? Ok(res) : NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }
}
