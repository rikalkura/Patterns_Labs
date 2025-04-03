using Lab_2.Domain.Dto;
using Lab_2.Domain.Entities;
using Lab_2.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lab_2.Application.Behaviors.Employee.Get;

public class GetEmployeesHandler(IAppDbContext appDbContext) : IRequestHandler<GetEmployeesQuery, List<EmployeeDto>>
{
    public async Task<List<EmployeeDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        return await appDbContext.Employees
            .Select(e => new EmployeeDto(
                e.Name,
                e.Position,
                e.Department))
            .ToListAsync(cancellationToken);
    }
}
