using MediatR;
using MicrodadosEnemSergipe.Domain.Abstractions;

namespace MicrodadosEnemSergipe.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}