public class FilterParticipantePresenca : BaseFilter {
	int dia;
	bool presente;

	public FilterParticipantePresenca() {}

	public void SetDia(int dia)
	{
		this.dia = dia;
	}

	public void SetPresenca(bool presente)
	{
		this.presente = presente;
	}

	public override AbstractQueryClass Filter(AbstractQueryClass query)
	{
		if (query.participanteDados == null) {
			throw new Exception("Campo provaAreaConhecimento é nulo");
		}

		query.participanteDados = query.participanteDados.Where(checkDia());

		if (next == null) {
			return query;
		}

		return next.Filter(query);
	}

	System.Linq.Expressions.Expression<Func<ParticipanteDados, bool>> checkDia() {
		if (dia == 1) return participante => participante.PresencaDia1 == presente;
		return participante => participante.PresencaDia2 == presente;
	}
}
