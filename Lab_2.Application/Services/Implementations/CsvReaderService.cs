using CsvHelper;
using CsvHelper.Configuration;
using Lab_2.Application.Services.Abstractions;
using Lab_2.Domain.Dto;
using Lab_2.Domain.Entities;
using System.Globalization;
using System.Text;

namespace Lab_2.Application.Services.Implementations;

public class CsvReaderService : ICsvReaderService
{
    public async Task<List<EmployeeEntity>> ReadEmployeesAsync(string filePath, CancellationToken ct = default)
    {
        using var reader = new StreamReader(filePath, Encoding.UTF8);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HeaderValidated = null,
            MissingFieldFound = null
        });

        var employees = new List<EmployeeEntity>();

        await foreach (var record in csv.GetRecordsAsync<EmployeeCsvDto>(ct))
        {
            var employee = new EmployeeEntity(
                record.Name,
                record.Position,
                record.Department);

            employees.Add(employee);
        }

        return employees;
    }
}
