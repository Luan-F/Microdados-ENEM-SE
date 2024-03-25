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
		if (query.provasAreaConhecimento == null) {
			throw new Exception("Campo provaAreaConhecimento é nulo");
		}

		query.provasAreaConhecimento = query.provasAreaConhecimento.Where(checkDia());

		if (next == null) {
			return query;
		}

		return next.Filter(query);
	}

	System.Linq.Expressions.Expression<Func<ProvaAreaConhecimento, bool>> checkDia() {
		if (dia == 1) return prova => (prova.PresencaCH && prova.PresencaLC) == presente;
		return prova => (prova.PresencaCN && prova.PresencaMT) == presente;
	}
}
