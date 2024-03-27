public class FilterSortAdpater {
	IFilter filter;
	ISort sort;

	public FilterSortAdpater(IFilter filter, ISort sort)
	{
		this.filter = filter;
		this.sort = sort;
	}

	public AbstractQueryClass Execute(AbstractQueryClass query, bool ascending)
	{
		query = this.filter.Filter(query);

		return this.sort.Sort(query, ascending);
	}
}
