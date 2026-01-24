using MediatR;

namespace AIPersonalHealthAndHabitCoach.Application.AI.Queries
{
    public class GetMetricsAnalyzeQuery : IRequest<string>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Question { get; set; } = string.Empty;
    }
}
