using AIPersonalHealthAndHabitCoach.Application.Interfaces;
using AIPersonalHealthAndHabitCoach.Domain.Dtos; 
using AIPersonalHealthAndHabitCoach.Domain.Entities;
using AIPersonalHealthAndHabitCoach.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AIPersonalHealthAndHabitCoach.Application.Metrics.Queries.GetMetricById
{
    public class GetMetricByIdQueryHandler : IRequestHandler<GetMetricByIdQuery, MetricDetailDto>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetMetricByIdQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<MetricDetailDto> Handle(GetMetricByIdQuery request, CancellationToken cancellationToken)
        {
            var metric = await _applicationDbContext.Metrics
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (metric is null)
            {
                throw new NotFoundException(nameof(Metric), request.Id.ToString());
            }

            var metricDto = new MetricDetailDto
            {
                Id = metric.Id,
                Date = metric.StartDateTimeUtc,
                ActivityType = (metric is Activity a) ? a.ActivityType : null,
                Tags = metric.GetTags()
            };


            if (metric is Sleep sleep)
            {
                metricDto.DurationMinutes = sleep.DurationMinutes;
                metricDto.SleepQuality = sleep.SleepQuality;
            }
            else if (metric is Meal meal)
            {
                metricDto.Description = meal.Description;
                metricDto.ProteinGrams = meal.ProteinGrams;
                metricDto.CarbonGrams = meal.CarbonGrams;
                metricDto.FatGrams = meal.FatGrams;
            }
            else if (metric is Activity activity)
            {
                metricDto.Description = activity.Description;
                metricDto.CaloriesBurned = activity.CaloriesBurned;
                metricDto.ActivityType = activity.ActivityType;
            }

            return metricDto;
        }
    }
}