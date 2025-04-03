using Lab_2.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lab_2.Application.Behaviors.Employee.Update;

public class UpdateEmployeeHandler(IAppDbContext appDbContext) : IRequestHandler<UpdateEmployeeCommand>
{
    public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await appDbContext.Employees.Where(
            e => e.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

        if (employee == null)
        {
            throw new Exception($"User with ID - {request.Id} - does not exist");
        }

        if (!string.IsNullOrWhiteSpace(request.Name))
        {
            employee.SetName(request.Name);
        }

        if (!string.IsNullOrWhiteSpace(request.Position))
        {
            employee.SetPosition(request.Position);
        }

        if (!string.IsNullOrWhiteSpace(request.Department))
        {
            employee.SetDepartment(request.Department);
        }

        await appDbContext.SaveChangesAsync(cancellationToken);
    }
}
