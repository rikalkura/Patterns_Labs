using Lab_2.Application.Services.Abstractions;
using Lab_2.Domain.Interfaces;
using MediatR;

namespace Lab_2.Application.Behaviors.Csv;

public class LoadCsvToDbHandler(
    IAppDbContext appDbContext,
    ICsvReaderService csvReaderService) 
    : IRequestHandler<LoadCsvToDbCommand, int>
{
    public async Task<int> Handle(LoadCsvToDbCommand request, CancellationToken cancellationToken)
    {
        var employees = await csvReaderService.ReadEmployeesAsync(request.FilePath, cancellationToken);

        if (employees.Count == 0)
            return 0;

        await appDbContext.Employees.AddRangeAsync(employees, cancellationToken);
        await appDbContext.SaveChangesAsync(cancellationToken);

        return employees.Count;
    }
}