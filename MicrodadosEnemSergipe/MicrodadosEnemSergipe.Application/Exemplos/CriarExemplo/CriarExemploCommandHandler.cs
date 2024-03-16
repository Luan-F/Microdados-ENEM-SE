using MicrodadosEnemSergipe.Application.Abstractions.Messaging;
using MicrodadosEnemSergipe.Domain.Abstractions;

namespace MicrodadosEnemSergipe.Application.Exemplos.CriarExemplo;

internal class CriarExemploCommandHandler : ICommandHandler<CriarExemploCommand, Guid>
{
    public Task<Result<Guid>> Handle(CriarExemploCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
