using Lab_2.Domain.Entities;
using Lab_2.Domain.Interfaces;
using MediatR;

namespace Lab_2.Application.Behaviors.Employee.Create;

public class CreateEmployeeHandler(IAppDbContext appDbContext) : IRequestHandler<CreateEmployeeCommand>
{
    public async Task Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = new EmployeeEntity(
            request.Name,
            request.Position,
            request.Department);


        await appDbContext.Employees.AddAsync(employee, cancellationToken);
        await appDbContext.SaveChangesAsync(cancellationToken);
    }
}
