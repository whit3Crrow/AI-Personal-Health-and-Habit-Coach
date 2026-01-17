namespace AIPersonalHealthAndHabitCoach.Domain.Common
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Items { get; init; }
        public int TotalCount { get; init; }
        public int PageSize { get; init; }
        public int CurrentPage { get; init; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

        public PagedResult(List<T> items, int count, int page, int pageSize)
        {
            Items = items;
            TotalCount = count;
            CurrentPage = page;
            PageSize = pageSize;
        }
    }
}