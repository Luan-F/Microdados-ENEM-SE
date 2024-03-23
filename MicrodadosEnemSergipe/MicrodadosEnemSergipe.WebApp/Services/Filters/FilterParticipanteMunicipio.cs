public class FilterParticipanteMunicipio : BaseFilter {
	string municipio;

	public FilterParticipanteMunicipio(string municipio)
	{
		this.municipio = municipio;
	}

	public override ParticipanteQueries Filter(ParticipanteQueries query)
	{
		query.escolaridades = query.escolaridades.Where(e => e.NomeMunicipio == municipio);

		if (next == null) {
			return query;
		}

		return next.Filter(query);
	}
}
