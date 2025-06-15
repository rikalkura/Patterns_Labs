using Lab_2.Domain.Dto;
using MediatR;

namespace Lab_2.Application.Behaviors.Employee.Get;

public record GetEmployeesQuery : IRequest<List<EmployeeDto>>;
