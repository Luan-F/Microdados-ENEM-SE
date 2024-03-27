public class SortMunicipioByNota : ISort {
	ENotas nota;

	public SortMunicipioByNota(ENotas nota) {
		this.nota = nota;
	}

	public AbstractQueryClass Sort(AbstractQueryClass query, bool ascending)
	{
		if (query.mediaMunicipios == null) {
			throw new Exception("Campo mediaMunicipios é nulo");
		}

		// FIX: Revisar para ver se é válido aplicar um strategy ou commander.
		switch (nota) {
			case ENotas.CH:
				if (ascending) query.mediaMunicipios = query.mediaMunicipios.OrderBy(m => m.NotaCH);
				else query.mediaMunicipios = query.mediaMunicipios.OrderByDescending(m => m.NotaCH);
				break;
			case ENotas.LC:
				if (ascending) query.mediaMunicipios = query.mediaMunicipios.OrderBy(m => m.NotaLC);
				else query.mediaMunicipios = query.mediaMunicipios.OrderByDescending(m => m.NotaLC);
				break;
			case ENotas.CN:
				if (ascending) query.mediaMunicipios = query.mediaMunicipios.OrderBy(m => m.NotaCN);
				else query.mediaMunicipios = query.mediaMunicipios.OrderByDescending(m => m.NotaCN);
				break;
			case ENotas.MT:
				if (ascending) query.mediaMunicipios = query.mediaMunicipios.OrderBy(m => m.NotaMT);
				else query.mediaMunicipios = query.mediaMunicipios.OrderByDescending(m => m.NotaMT);
				break;
			case ENotas.Redacao:
				if (ascending) query.mediaMunicipios = query.mediaMunicipios.OrderBy(m => m.NotaRedacao);
				else query.mediaMunicipios = query.mediaMunicipios.OrderByDescending(m => m.NotaRedacao);
				break;
			case ENotas.Geral:
				if (ascending) query.mediaMunicipios = query.mediaMunicipios.OrderBy(m => m.NotaGeral);
				else query.mediaMunicipios = query.mediaMunicipios.OrderByDescending(m => m.NotaGeral);
				break;
		}

		return query;
	}
}
