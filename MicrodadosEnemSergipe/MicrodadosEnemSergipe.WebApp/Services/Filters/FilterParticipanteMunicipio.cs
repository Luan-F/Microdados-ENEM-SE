public class FilterParticipanteMunicipio : BaseFilter {
	string municipio;

	public FilterParticipanteMunicipio(string municipio)
	{
		this.municipio = municipio;
	}

	public override AbstractQueryClass Filter(AbstractQueryClass query)
	{
		if (query.participanteDados == null) {
			throw new Exception("Campo participanteDados é nulo");
		}

		query.participanteDados = query.participanteDados.Where(e => e.NomeMunicipio == municipio);

		if (next == null) {
			return query;
		}

		return next.Filter(query);
	}
}
