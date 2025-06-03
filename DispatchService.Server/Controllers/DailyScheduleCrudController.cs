using DispatchService.Application.Contracts;
using DispatchService.Application.Contracts.DailySchedule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DispatchService.Server.Controllers;
/// <summary>
/// Контроллер для CRUD-операций над ежедневными графиками
/// </summary>
/// <param name="crudService">CRUD-служба</param>
[Route("api/[controller]")]
[ApiController]
public class DailyScheduleCrudController(ICrudService<DailyScheduleDto, DailyScheduleCreateUpdateDto, int> crudService) 
    : CrudControllerBase<DailyScheduleDto, DailyScheduleCreateUpdateDto, int>(crudService);
