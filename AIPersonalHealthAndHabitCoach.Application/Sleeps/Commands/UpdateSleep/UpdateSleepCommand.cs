using AIPersonalHealthAndHabitCoach.Domain.Enums;
using MediatR;

public class UpdateSleepCommand : IRequest
{
    public required Guid Id { get; set; } 
    public int DurationMinutes { get; set; }
    public SleepQuality SleepQuality { get; set; }
    public  DateTime StartDate { get; set; }
}