public abstract class BaseFilter : IFilter {
	protected IFilter? next;

	public void SetFilter(IFilter filter) {
		this.next = filter;
	}
	public abstract AbstractQueryClass Filter(AbstractQueryClass query);
}
