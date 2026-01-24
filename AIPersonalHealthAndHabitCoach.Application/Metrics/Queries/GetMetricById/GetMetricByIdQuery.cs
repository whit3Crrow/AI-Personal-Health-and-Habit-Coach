using AIPersonalHealthAndHabitCoach.Domain.Entities;
using AIPersonalHealthAndHabitCoach.Domain.Dtos;
using MediatR;

namespace AIPersonalHealthAndHabitCoach.Application.Metrics.Queries.GetMetricById
{
    public class GetMetricByIdQuery : IRequest<MetricDetailDto>
    {
        public Guid Id { get; set; }

        public GetMetricByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}