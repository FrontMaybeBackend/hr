using Application.Dto;
using Application.Exceptions;
using Application.Interfaces;
using hr.Domain.Entity;
using hr.Domain.Interfaces;

namespace Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;
    private readonly AutoMapper.IMapper _mapper;

    public EmployeeService(IEmployeeRepository repository, AutoMapper.IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<List<Employee>> GetEmployees()
    {
        return _repository.GetAll();
    }

    public async Task<EmployeeResponseDto> CreateEmployee(CreateEmployeeDto createEmployeeDto)
    {
        var employee = _mapper.Map<Employee>(createEmployeeDto);
        await _repository.Create(employee);
        return _mapper.Map<EmployeeResponseDto>(employee);
    }

    public async Task DeleteEmployee(int id)
    {
       var employee = await  _repository.FindEmployeeAsync(id);
       if (employee is null)
       {
           throw new NotFoundException($"Employee with id {id} not found");
       }
       await _repository.DeleteEmployee(id);
    }
    
}