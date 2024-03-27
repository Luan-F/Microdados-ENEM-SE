public abstract class AbstractQueryClass {
	public IQueryable<ProvaAreaConhecimento>? provasAreaConhecimento;
	public IQueryable<Redacao>? redacoes;
	public IQueryable<Escolaridade>? escolaridades;
	public IQueryable<Participante>? participantes;
	public IQueryable<MediaMunicipio>? mediaMunicipios;
	public IQueryable<ParticipanteDados>? participanteDados;

	public void CopyFromAbstract(AbstractQueryClass queryClass)
	{
		this.provasAreaConhecimento = queryClass.provasAreaConhecimento;
		this.redacoes = queryClass.redacoes;
		this.escolaridades = queryClass.escolaridades;
		this.participantes = queryClass.participantes;
		this.mediaMunicipios = queryClass.mediaMunicipios;
		this.participanteDados = queryClass.participanteDados;
	}

	public bool IsRedacoesNull()
	{
		return redacoes == null;
	}

	public bool IsEscolaridadesNull()
	{
		return escolaridades == null;
	}

	public bool IsParticipantesNull()
	{
		return participantes == null;
	}

	public bool IsProvasAreaConhecimentoNull()
	{
		return provasAreaConhecimento == null;
	}
}
