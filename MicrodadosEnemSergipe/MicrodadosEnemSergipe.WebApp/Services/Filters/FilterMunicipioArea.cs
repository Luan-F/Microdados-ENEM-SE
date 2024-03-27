public class FilterMunicipioArea : BaseFilter {
	private float[]? rangeCH, rangeCN, rangeMT, rangeLC, rangeGeral;

	public FilterMunicipioArea(float[]? rangeCH, float[]? rangeCN, float[]? rangeLC, float[]? rangeMT, float[]? rangeGeral)
	{
		this.rangeCH = rangeCH;
		this.rangeCN = rangeCN;
		this.rangeMT = rangeMT;
		this.rangeLC = rangeLC;
		this.rangeGeral = rangeGeral;
	}

	public override AbstractQueryClass Filter(AbstractQueryClass query)
	{
		if (query.mediaMunicipios == null) {
			throw new Exception("Campo mediaMunicipios é nulo");
		}

		if (rangeCH != null) {
			query.mediaMunicipios = query
				.mediaMunicipios.Where(
						p => p.NotaCH >= rangeCH[0]
						&& p.NotaCH <= rangeCH[1]);
		}

		if (rangeCN != null) {
			query.mediaMunicipios = query
				.mediaMunicipios.Where(
						p => p.NotaCN >= rangeCN[0]
						&& p.NotaCN <= rangeCN[1]);
		}

		if (rangeMT != null) {
			query.mediaMunicipios = query
				.mediaMunicipios.Where(
						p => p.NotaMT >= rangeMT[0]
						&& p.NotaMT <= rangeMT[1]);
		}

		if (rangeLC != null) {
			query.mediaMunicipios = query
				.mediaMunicipios.Where(
						p => p.NotaLC >= rangeLC[0]
						&& p.NotaLC <= rangeLC[1]);
		}

		if (rangeGeral != null) {
			query.mediaMunicipios = query
				.mediaMunicipios.Where(
						p => p.NotaGeral >= rangeGeral[0]
						&& p.NotaGeral <= rangeGeral[1]);
		}

		if (next == null) {
			return query;
		}

		return next.Filter(query);
	}
}
