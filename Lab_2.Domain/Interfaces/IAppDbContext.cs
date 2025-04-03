using Lab_2.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab_2.Domain.Interfaces;

public interface IAppDbContext
{
    DbSet<EmployeeEntity> Employees { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
