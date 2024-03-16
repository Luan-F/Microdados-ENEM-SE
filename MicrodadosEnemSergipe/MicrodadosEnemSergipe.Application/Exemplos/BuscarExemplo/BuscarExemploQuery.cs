using MicrodadosEnemSergipe.Application.Abstractions.Messaging;

namespace MicrodadosEnemSergipe.Application.Exemplos.BuscarExemplo;

public sealed record BuscarExemploQuery(Guid ExemploId) : IQuery<ExemploResponse>;