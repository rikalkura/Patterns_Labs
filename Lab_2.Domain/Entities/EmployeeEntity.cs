using MediatR;

namespace Lab_2.Domain.Entities;

public class EmployeeEntity : BaseEntity
{
    public EmployeeEntity(
        string name,
        string position,
        string department)
    {
        Name = name;
        Position = position;
        Department = department;
    }

    public string Name { get; private set; }
    public string Position { get; private set; }
    public string Department { get; private set; }

    public void SetName(string name)
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            Name = name;
        }
    }
    public void SetPosition(string position) 
    {
        if (!string.IsNullOrWhiteSpace(position)) 
        {
            Position = position; 
        } 
    }

    public void SetDepartment(string department)
    {
        if (!string.IsNullOrWhiteSpace(department))
        {
            Department = department;
        };
    }
}
