using MediatR;
using MicrodadosEnemSergipe.Domain.Abstractions;

namespace MicrodadosEnemSergipe.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>, IBaseCommand
{
}

public interface ICommand<TReponse> : IRequest<Result<TReponse>>, IBaseCommand
{
}

public interface IBaseCommand
{
}