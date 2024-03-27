public class SortMunicipioByNome : ISort {
	public AbstractQueryClass Sort(AbstractQueryClass query, bool ascending)
	{
		if (query.mediaMunicipios == null) {
			throw new Exception("Campo mediaMunicipios é nulo");
		}

		if (ascending) query.mediaMunicipios = query.mediaMunicipios.OrderBy(m => m.NomeMunicipio);
		else query.mediaMunicipios = query.mediaMunicipios.OrderByDescending(m => m.NomeMunicipio);

		return query;
	}
}
