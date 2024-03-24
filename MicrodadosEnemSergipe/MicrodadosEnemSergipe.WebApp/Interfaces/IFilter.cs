public interface IFilter {
	public void SetFilter(IFilter filter);
	public AbstractQueryClass Filter(AbstractQueryClass query);
}
