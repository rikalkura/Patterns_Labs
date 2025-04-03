using MediatR;

namespace Lab_2.Application.Behaviors.Csv;

public record LoadCsvToDbCommand(string FilePath) : IRequest<int>;