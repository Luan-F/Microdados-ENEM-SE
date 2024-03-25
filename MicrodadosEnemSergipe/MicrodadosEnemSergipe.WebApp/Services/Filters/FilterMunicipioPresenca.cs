public class FilterMunicipioPresenca : BaseFilter {
	int dia;
	float[] presencaRange = { 0F, 100F };

	public FilterMunicipioPresenca() {

	}

	public void SetDia(int dia)
	{
		this.dia = dia;
	}

	public void SetPresenca(float[] range)
	{
		this.presencaRange = range;
	}

	public override AbstractQueryClass Filter(AbstractQueryClass query)
	{
		if (query.mediaMunicipios == null) {
			throw new Exception("Campo provaAreaConhecimento é nulo");
		}

		query.mediaMunicipios = query.mediaMunicipios.Where(checkDia());

		if (next == null) {
			return query;
		}

		return next.Filter(query);
	}

	System.Linq.Expressions.Expression<Func<MediaMunicipio, bool>> checkDia() {
		Console.WriteLine($"{presencaRange[0]}, {presencaRange[1]}");
		if (dia == 1) return x => x.PresencaDia1 >= presencaRange[0] && x.PresencaDia1 <= presencaRange[1];
		return x => x.PresencaDia2 >= presencaRange[0] && x.PresencaDia2 <= presencaRange[1];
	}
}
