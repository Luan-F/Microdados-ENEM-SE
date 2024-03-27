public class SortMunicipioByPresenca : ISort {
	EDiaEnem dia;
	float[] range;

	public SortMunicipioByPresenca(EDiaEnem dia, float[] range)
	{
		this.dia = dia;
		this.range = range;
	}

	public AbstractQueryClass Sort(AbstractQueryClass query, bool ascending)
	{
		if (query.mediaMunicipios == null) {
			throw new Exception("Campo mediaMunicipios é nulo");
		}

		switch (dia) {
			case EDiaEnem.Dia1:
				if (ascending) query.mediaMunicipios = query.mediaMunicipios.OrderBy(m => m.PresencaDia1 >= range[0] && m.PresencaDia1 <= range[1]);
				else query.mediaMunicipios = query.mediaMunicipios.OrderByDescending(m => m.PresencaDia1 >= range[0] && m.PresencaDia1 <= range[1]);
				break;
			case EDiaEnem.Dia2:
				if (ascending) query.mediaMunicipios = query.mediaMunicipios.OrderBy(m => m.PresencaDia2 >= range[0] && m.PresencaDia2 <= range[1]);
				else query.mediaMunicipios = query.mediaMunicipios.OrderByDescending(m => m.PresencaDia2 >= range[0] && m.PresencaDia2 <= range[1]);
				break;
		}

		return query;
	}
}
