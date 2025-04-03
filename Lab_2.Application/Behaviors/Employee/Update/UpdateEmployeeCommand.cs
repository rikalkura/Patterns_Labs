using MediatR;
using System.Text.Json.Serialization;

namespace Lab_2.Application.Behaviors.Employee.Update;

public class UpdateEmployeeCommand : IRequest
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public string Department { get; set; }
}
