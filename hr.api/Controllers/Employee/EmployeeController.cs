using hr.Application.Employee;
using Microsoft.AspNetCore.Mvc;

namespace hr.Controllers.Employee;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{   
    private readonly IEmployeeRepository _repository;

    public EmployeeController(IEmployeeRepository repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public async Task<ActionResult> GetEmployees()
    {
        var list = await _repository.GetAll();
        return Ok(list);
    }
    
    
}