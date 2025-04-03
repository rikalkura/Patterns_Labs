using MediatR;

namespace Lab_2.Application.Behaviors.Employee.Create;

public record CreateEmployeeCommand(
    string Name,
    string Position,
    string Department) : IRequest;
