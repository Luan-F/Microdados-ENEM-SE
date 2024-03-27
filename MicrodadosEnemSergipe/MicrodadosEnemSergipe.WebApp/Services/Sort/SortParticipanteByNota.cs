public class SortParticipanteByNota : ISort {
	ENotas nota;

	public SortParticipanteByNota(ENotas nota) {
		this.nota = nota;
	}

	public AbstractQueryClass Sort(AbstractQueryClass query, bool ascending)
	{
		if (query.participanteDados == null) {
			throw new Exception("Campo participanteDados é nulo");
		}

		// FIX: Revisar para ver se é válido aplicar um strategy ou commander.
		switch (nota) {
			case ENotas.CH:
				if (ascending) query.participanteDados = query.participanteDados.OrderBy(m => m.NotaCH);
				else query.participanteDados = query.participanteDados.OrderByDescending(m => m.NotaCH);
				break;
			case ENotas.LC:
				if (ascending) query.participanteDados = query.participanteDados.OrderBy(m => m.NotaLC);
				else query.participanteDados = query.participanteDados.OrderByDescending(m => m.NotaLC);
				break;
			case ENotas.CN:
				if (ascending) query.participanteDados = query.participanteDados.OrderBy(m => m.NotaCN);
				else query.participanteDados = query.participanteDados.OrderByDescending(m => m.NotaCN);
				break;
			case ENotas.MT:
				if (ascending) query.participanteDados = query.participanteDados.OrderBy(m => m.NotaMT);
				else query.participanteDados = query.participanteDados.OrderByDescending(m => m.NotaMT);
				break;
			case ENotas.Redacao:
				if (ascending) query.participanteDados = query.participanteDados.OrderBy(m => m.NotaRedacao);
				else query.participanteDados = query.participanteDados.OrderByDescending(m => m.NotaRedacao);
				break;
			case ENotas.Geral:
				if (ascending) query.participanteDados = query.participanteDados.OrderBy(m => m.NotaGeral);
				else query.participanteDados = query.participanteDados.OrderByDescending(m => m.NotaGeral);
				break;
		}

		return query;
	}
}
