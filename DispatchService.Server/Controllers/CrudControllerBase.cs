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
    public async Task<ActionResult<TDto>> Create(TCreateUpdateDto newDto)
    {
        try
        {
            var res = await crudService.Create(newDto);
            return res != null ? Ok(res) : StatusCode(400);
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
    public async Task<ActionResult<TDto>> Edit(TKey id, TCreateUpdateDto newDto)
    {
        try
        {
            var res = await crudService.Update(id, newDto);
            return res != null ? Ok(res) : StatusCode(400);
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
    public async Task <ActionResult<TDto>> Delete(TKey id)
    {
        try
        {
            var res = await crudService.Delete(id);
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
    public async Task <ActionResult<IList<TDto>>> GetAll()
    {
        try
        {
            var res = await crudService.GetList();
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
    public async Task <ActionResult<TDto>> Get(TKey id)
    {
        try
        {
            var res = await crudService.GetById(id);
            return res != null ? Ok(res) : NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }
}
