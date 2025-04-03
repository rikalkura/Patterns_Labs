using Lab_2.Domain.Entities;

namespace Lab_2.Application.Services.Abstractions;

public interface ICsvReaderService
{
    Task<List<EmployeeEntity>> ReadEmployeesAsync(string filePath, CancellationToken ct = default);
}
