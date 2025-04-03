using Lab_2.Domain.Dto;
using MediatR;

namespace Lab_2.Application.Behaviors.Employee.GetById;

public record GetEmployeeByIdQuery(Guid Id) : IRequest<EmployeeDto>;
