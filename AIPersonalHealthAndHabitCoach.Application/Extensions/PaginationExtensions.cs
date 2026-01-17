using Microsoft.EntityFrameworkCore;
using AIPersonalHealthAndHabitCoach.Domain.Common;

namespace AIPersonalHealthAndHabitCoach.Application.Extensions
{
    public static class PaginationExtensions
    {
        public static async Task<PagedResult<T>> GetPagedAsync<T>(
            this IQueryable<T> query,
            int page,
            int pageSize,
            CancellationToken cancellationToken)
        {
            var totalCount = await query.CountAsync(cancellationToken);

            var skip = (page - 1) * pageSize;
            var items = await query
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return new PagedResult<T>(items, totalCount, page, pageSize);
        }
    }
}
