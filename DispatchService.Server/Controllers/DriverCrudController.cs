using DispatchService.Application.Contracts;
using DispatchService.Application.Contracts.Driver;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DispatchService.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DriverCrudController(ICrudService<DriverDto, DriverCreateUpdateDto, int> crudService) 
    : CrudControllerBase<DriverDto, DriverCreateUpdateDto, int>(crudService);
