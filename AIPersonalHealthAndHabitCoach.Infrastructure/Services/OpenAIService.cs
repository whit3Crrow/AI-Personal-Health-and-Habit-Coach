using AIPersonalHealthAndHabitCoach.Domain.Interfaces;
using OpenAI.Chat;

namespace AIPersonalHealthAndHabitCoach.Infrastructure.Services
{
    public class OpenAIService : IOpenAIService
    {
        public async Task<string> SendPromptAsync(string prompt, string apiKey, string model)
        {
            ChatClient client = new(model: model, apiKey: apiKey);

            ChatCompletion completion = await client.CompleteChatAsync(prompt);

            return completion.Content[0].Text;
        }
    }
}
