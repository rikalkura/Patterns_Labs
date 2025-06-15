using Lab_2.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lab_2.Application.Behaviors.Employee.Delete;

public class DeleteEmployeeHandler(IAppDbContext appDbContext) : IRequestHandler<DeleteEmployeeCommand>
{
    public async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await appDbContext.Employees.Where(
            e => e.Id == request.Id).FirstOrDefaultAsync(cancellationToken);


        if (employee == null) 
        {
            throw new Exception($"User with ID - {request.Id} - does not exist");
        }

        appDbContext.Employees.Remove(employee);
        await appDbContext.SaveChangesAsync(cancellationToken);
    }
}
