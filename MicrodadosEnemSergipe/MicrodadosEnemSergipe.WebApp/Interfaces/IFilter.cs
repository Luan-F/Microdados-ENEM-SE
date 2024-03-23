public interface IFilter {
	public void SetFilter(IFilter filter);
	public ParticipanteQueries Filter(ParticipanteQueries query);
}
