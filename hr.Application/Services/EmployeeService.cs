using hr.Application.Dto;
using hr.Application.Interfaces;
using hr.Domain.Entity;
using hr.Domain.Interfaces;

namespace hr.Application.Services;

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

    public async Task<ResponseEmployeeDto> CreateEmployee(CreateEmployeeDto createEmployeeDto)
    {
        var employee = _mapper.Map<Employee>(createEmployeeDto);
        await _repository.Create(employee);
        return _mapper.Map<ResponseEmployeeDto>(employee);
    }

    public async Task DeleteEmployee(int id)
    {
        await _repository.DeleteEmployee(id);
    }
}