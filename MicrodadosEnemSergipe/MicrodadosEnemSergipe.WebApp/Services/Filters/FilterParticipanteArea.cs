public class FilterParticipanteArea : BaseFilter {
	private float[]? rangeCH, rangeCN, rangeMT, rangeLC;

	public FilterParticipanteArea(float[]? rangeCH, float[]? rangeCN, float[]? rangeLC, float[]? rangeMT)
	{
		this.rangeCH = rangeCH;
		this.rangeCN = rangeCN;
		this.rangeMT = rangeMT;
		this.rangeLC = rangeLC;
	}

	public override AbstractQueryClass Filter(AbstractQueryClass query)
	{
		if (query.provasAreaConhecimento == null) {
			throw new Exception("Campo provasAreaConhecimento é nulo");
		}

		if (rangeCH != null) {
			query.provasAreaConhecimento = query
				.provasAreaConhecimento.Where(
						p => p.NotaCH >= rangeCH[0]
						&& p.NotaCH <= rangeCH[1]);
		}

		if (rangeCN != null) {
			query.provasAreaConhecimento = query
				.provasAreaConhecimento.Where(
						p => p.NotaCN >= rangeCN[0]
						&& p.NotaCN <= rangeCN[1]);
		}

		if (rangeMT != null) {
			query.provasAreaConhecimento = query
				.provasAreaConhecimento.Where(
						p => p.NotaMT >= rangeMT[0]
						&& p.NotaMT <= rangeMT[1]);
		}

		if (rangeLC != null) {
			query.provasAreaConhecimento = query
				.provasAreaConhecimento.Where(
						p => p.NotaLC >= rangeLC[0]
						&& p.NotaLC <= rangeLC[1]);
		}

		if (next == null) {
			return query;
		}

		return next.Filter(query);
	}
}
