using MediatR;

namespace AIPersonalHealthAndHabitCoach.Application.Metrics.Commands.DeleteMetricById
{
    public class DeleteMetricByIdCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteMetricByIdCommand(Guid id)
        {
            Id = id;
        }
    }
}