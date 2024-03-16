using MicrodadosEnemSergipe.Application.Abstractions.Messaging;
using MicrodadosEnemSergipe.Domain.Abstractions;

namespace MicrodadosEnemSergipe.Application.Exemplos.BuscarExemplo;

internal sealed class GetBookingQueryHandler : IQueryHandler<BuscarExemploQuery, ExemploResponse>
{
    private readonly dynamic _sqlConnectionFactory;

    public GetBookingQueryHandler(dynamic sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<ExemploResponse>> Handle(BuscarExemploQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                id AS Id,
                titulo AS Titulo,
            FROM bookings
            WHERE id = @ExemploId
            """;

        var exemplo = await connection.QueryFirstOrDefaultAsync<ExemploResponse>(
            sql,
            new
            {
                request.ExemploId
            });

        return exemplo;
    }
}