public class SortParticipanteByMunicipio : ISort {
	public AbstractQueryClass Sort(AbstractQueryClass query, bool ascending)
	{
		if (query.participanteDados == null) {
			throw new Exception("Campo mediaParticipantes é nulo");
		}

		if (ascending) query.participanteDados = query.participanteDados.OrderBy(m => m.NomeMunicipio);
		else query.participanteDados = query.participanteDados.OrderByDescending(m => m.NomeMunicipio);

		return query;
	}
}
