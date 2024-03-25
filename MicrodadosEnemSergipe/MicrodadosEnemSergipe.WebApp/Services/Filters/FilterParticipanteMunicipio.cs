public class FilterParticipanteMunicipio : BaseFilter {
	string municipio;

	public FilterParticipanteMunicipio(string municipio)
	{
		this.municipio = municipio;
	}

	public override AbstractQueryClass Filter(AbstractQueryClass query)
	{
		if (query.escolaridades == null) {
			throw new Exception("Campo escolaridades é nulo");
		}

		query.escolaridades = query.escolaridades.Where(e => e.NomeMunicipio == municipio);

		if (next == null) {
			return query;
		}

		return next.Filter(query);
	}
}
