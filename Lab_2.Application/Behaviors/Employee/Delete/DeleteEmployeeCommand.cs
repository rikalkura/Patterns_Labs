using MediatR;

namespace Lab_2.Application.Behaviors.Employee.Delete;

public record DeleteEmployeeCommand(Guid Id) : IRequest;
