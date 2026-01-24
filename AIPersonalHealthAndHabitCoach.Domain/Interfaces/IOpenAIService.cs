namespace AIPersonalHealthAndHabitCoach.Domain.Interfaces
{
    public interface IOpenAIService
    {
        Task<string> SendPromptAsync(string prompt, string apiKey, string model);
    }
}
