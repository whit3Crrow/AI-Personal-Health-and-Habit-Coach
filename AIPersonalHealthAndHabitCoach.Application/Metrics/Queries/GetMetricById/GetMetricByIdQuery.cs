using AIPersonalHealthAndHabitCoach.Domain.Entities;
using MediatR;

namespace AIPersonalHealthAndHabitCoach.Application.Metrics.Queries.GetMetricById
{
    public class GetMetricByIdQuery : IRequest<Metric>
    {
        public Guid Id { get; set; }

        public GetMetricByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}