using AIPersonalHealthAndHabitCoach.Application.Interfaces;
using AIPersonalHealthAndHabitCoach.Domain.Exceptions;
using AIPersonalHealthAndHabitCoach.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AIPersonalHealthAndHabitCoach.Application.AI.Queries
{
    public class GetMetricsAnalyzeQueryHandler : IRequestHandler<GetMetricsAnalyzeQuery, string>
    {
        private readonly IConfiguration _configuration;
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMetricsStatsService _metricsStatsService;
        private readonly IOpenAIService _openAIService;
        private readonly JsonSerializerOptions _jsonOptions;

        public GetMetricsAnalyzeQueryHandler(
            IConfiguration configuration,
            IApplicationDbContext applicationDbContext, 
            IMetricsStatsService metricsStatsService,
            IOpenAIService openAIService)
        {
            _configuration = configuration;
            _applicationDbContext = applicationDbContext;
            _metricsStatsService = metricsStatsService;
            _openAIService = openAIService;

            _jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() }
            };
        }

        public async Task<string> Handle(GetMetricsAnalyzeQuery request, CancellationToken cancellationToken)
        {
            var apiKey = _configuration["OpenAI:ApiKey"];
            var model = _configuration["OpenAI:Model"];

            if (apiKey is null || model is null)
            {
                throw new InvalidOperationException("OpenAI configuration is missing.");
            }

            var user = await _applicationDbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);

            if (user is null)
            {
                throw new BadRequestException("You must create a user before using this feature");
            }

            var metricStats = await _metricsStatsService.GetMetricsSummaryAsync(
                request.StartDate,
                request.EndDate,
                cancellationToken);

            var metrics = await _applicationDbContext.Metrics
                .AsNoTracking()
                .Where(x => x.StartDateTimeUtc >= request.StartDate && x.StartDateTimeUtc < request.EndDate)
                .OrderBy(x => x.StartDateTimeUtc)
                .Take(100)
                .ToListAsync(cancellationToken);

            string metricStatsJson = JsonSerializer.Serialize(metricStats, _jsonOptions);
            string metricsJson = JsonSerializer.Serialize(metrics, _jsonOptions);
            string userQuestion = string.IsNullOrWhiteSpace(request.Question) ? "Brak pytania." : request.Question;

            var prompt = $@"
                Jesteś profesjonalnym, empatycznym Trenerem Zdrowia i Nawyków (AI Personal Health Coach).
                Twoim celem jest analiza danych biometrycznych, wykrywanie trendów i motywowanie użytkownika.

                --- PROFIL UŻYTKOWNIKA ---
                Wiek: {user.Age} lat
                Waga: {user.WeightKilograms} kg
                Wzrost: {user.HeightCentimeters} cm
                (Wskazówka: Uwzględnij w analizie BMI).

                --- PODSUMOWANIE STATYSTYCZNE (CAŁY OKRES: {request.StartDate:yyyy-MM-dd} - {request.EndDate:yyyy-MM-dd}) ---
                Poniższe statystyki obejmują WSZYSTKIE dane z wybranego zakresu dat:
                {metricStatsJson}
    
                --- SZCZEGÓŁOWY DZIENNIK (MAKSYMALNIE PIERWSZE 100 WPISÓW OD DATY STARTOWEJ) ---
                UWAGA DLA AI: Poniższa lista zawiera maksymalnie 100 pierwszych rekordów zaczynając od {request.StartDate:yyyy-MM-dd}.
                Do analizy konkretnych dni/nawyków używaj poniższej listy.
                {metricsJson}

                --- INSTRUKCJA ODPOWIEDZI ---
                Przeanalizuj powyższe dane i wygeneruj odpowiedź.
                Nie bądź robotem - bądź wnikliwym trenerem.

                ### 1. Odpowiedź na pytanie
                Pytanie użytkownika: ""{userQuestion}""
                Udziel konkretnej odpowiedzi (jeśli brak pytania zignoruj tą część).

                ### 2. Kluczowe Wnioski i Analiza
                W tej sekcji masz pełną swobodę analityczną. Nie odnoś się punkt po punkcie do poniższej listy – to tylko Twoje **wskazówki pomocnicze**. 
                Zamiast tego, samodzielnie wybierz i opisz 3-4 najistotniejsze zjawiska, które zauważyłeś w danych. Połącz fakty w spójną historię.

                Obszary, na które warto zwrócić uwagę (korzystaj wybiórczo, tam gdzie widzisz problem/sukces):
                - Związki przyczynowo-skutkowe (np. jak zły sen w poniedziałek wpłynął na dietę we wtorek).
                - Bilans energetyczny (czy 'paliwo' z jedzenia pasuje do aktywności).
                - Anomalie (np. ""efekt weekendu"", nagłe zrywy, dni totalnego lenistwa).

                Twoim zadaniem jest wyłowienie tego, co dla tego konkretnego użytkownika jest teraz najważniejsze. Pisz płynnym tekstem lub w punktach, ale unikaj formatu ankiety.

                ZAKOŃCZENIE:
                Zakończ jednym konkretnym ""Zadaniem na jutro"". To ma być ""game changer"" dla tego użytkownika.
            ";

            var aiResponse = await _openAIService.SendPromptAsync(prompt, apiKey, model);
            return aiResponse;
        }
    }
}
