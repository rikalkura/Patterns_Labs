using Lab_2.Domain.Dto;
using Lab_2.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lab_2.Application.Behaviors.Employee.GetById;

public class GetEmployeeByIdHandler(IAppDbContext appDbContext) : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
{
    public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var employee = await appDbContext.Employees.FirstOrDefaultAsync(
            e => e.Id == request.Id, cancellationToken);

        if (employee == null) 
        {
            throw new Exception($"User with ID - {request.Id} - does not exist");
        }

        return new EmployeeDto(
            employee.Name,
            employee.Position,
            employee.Department);
    }
}
