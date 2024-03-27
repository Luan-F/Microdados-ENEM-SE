using MediatR;
using MicrodadosEnemSergipe.Domain.Abstractions;

namespace MicrodadosEnemSergipe.Application.Abstractions.Messaging;


public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}