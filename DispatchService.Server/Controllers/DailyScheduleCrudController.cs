using DispatchService.Application.Contracts;
using DispatchService.Application.Contracts.DailySchedule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DispatchService.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DailyScheduleCrudController(ICrudService<DailyScheduleDto, DailyScheduleCreateUpdateDto, int> crudService) 
    : CrudControllerBase<DailyScheduleDto, DailyScheduleCreateUpdateDto, int>(crudService);
