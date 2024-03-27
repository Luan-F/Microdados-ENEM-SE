public class FilterParticipanteRedacao : BaseFilter {
	private float[]? rangeComp1, rangeComp2, rangeComp3, rangeComp4, rangeComp5, rangeRedacao;

	public FilterParticipanteRedacao(
			float[]? rangeComp1, float[]? rangeComp2,
			float[]? rangeComp3, float[]? rangeComp4,
			float[]? rangeComp5, float[]? rangeRedacao
		)
	{
		this.rangeComp1 = rangeComp1;
		this.rangeComp2 = rangeComp2;
		this.rangeComp3 = rangeComp3;
		this.rangeComp4 = rangeComp4;
		this.rangeComp5 = rangeComp5;
		this.rangeRedacao = rangeRedacao;
	}

	public override AbstractQueryClass Filter(AbstractQueryClass query)
	{
		if (query.participanteDados == null) {
			throw new Exception("Campo participanteDados é nulo");
		}

		if (rangeComp1 != null) {
			query.participanteDados = query
				.participanteDados.Where(
						p => p.NotaComp1 >= rangeComp1[0]
						&& p.NotaComp1 <= rangeComp1[1]);
		}

		if (rangeComp2 != null) {
			query.participanteDados = query
				.participanteDados.Where(
						p => p.NotaComp2 >= rangeComp2[0]
						&& p.NotaComp2 <= rangeComp2[1]);
		}

		if (rangeComp3 != null) {
			query.participanteDados = query
				.participanteDados.Where(
						p => p.NotaComp3 >= rangeComp3[0]
						&& p.NotaComp3 <= rangeComp3[1]);
		}

		if (rangeComp4 != null) {
			query.participanteDados = query
				.participanteDados.Where(
						p => p.NotaComp4 >= rangeComp4[0]
						&& p.NotaComp4 <= rangeComp4[1]);
		}

		if (rangeComp5 != null) {
			query.participanteDados = query
				.participanteDados.Where(
						p => p.NotaComp5 >= rangeComp5[0]
						&& p.NotaComp5 <= rangeComp5[1]);
		}

		if (rangeRedacao != null) {
			query.participanteDados = query
				.participanteDados.Where(
						p => p.NotaRedacao >= rangeRedacao[0]
						&& p.NotaRedacao <= rangeRedacao[1]);
		}

		if (next == null) {
			return query;
		}

		return next.Filter(query);
	}
}
