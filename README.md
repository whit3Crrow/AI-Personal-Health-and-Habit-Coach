# AI Personal Health and Habit Coach

API do zarządzania metrykami zdrowotnymi użytkownika (sen, aktywność, posiłki) z możliwością generowania inteligentnych rekomendacji AI.  

## Endpoints

### 1. Metrics

| Metoda | Endpoint | Parametry | Opis |
|--------|---------|-----------------|------|
| GET    | /metrics | Query: `page` (optional), `pageSize` (optional), `type` (optional: sleep, activity, meal) | Pobiera wszystkie metryki z paginacją i możliwością filtrowania po typie |
| GET    | /metrics/{id} | Path: `id` | Pobiera konkretną metrykę |
| POST   | /metrics/sleep | Body: `SleepMetric` DTO (`DurationMinutes`, `SleepQuality`, `DateUtc`) | Dodaje nową metrykę snu |
| POST   | /metrics/activity | Body: `ActivityMetric` DTO (`Steps`, `CaloriesBurned`, `DateUtc`) | Dodaje nową metrykę aktywności |
| POST   | /metrics/meal | Body: `MealMetric` DTO (`MealType`, `Calories`, `DateUtc`) | Dodaje nową metrykę posiłku |
| PUT    | /metrics/sleep/{id} | Path: `id`, Body: `SleepMetric` DTO | Aktualizuje metrykę snu |
| PUT    | /metrics/activity/{id} | Path: `id`, Body: `ActivityMetric` DTO | Aktualizuje metrykę aktywności |
| PUT    | /metrics/meal/{id} | Path: `id`, Body: `MealMetric` DTO | Aktualizuje metrykę posiłku |
| DELETE | /metrics/{id} | Path: `id` | Usuwa metrykę |

---

### 2. Stats

| Metoda | Endpoint | Query | Opis |
|--------|---------|-------|------|
| GET    | /stats/summary | `startDate`, `endDate` | Raport ogólny w zadanym okresie |
| GET    | /stats/sleep | `startDate`, `endDate` | Statystyki snu |
| GET    | /stats/activity | `startDate`, `endDate` | Statystyki aktywności |
| GET    | /stats/meal | `startDate`, `endDate` | Statystyki posiłków |

---

### 3. AI Module

| Metoda | Endpoint | Query | Opis |
|--------|---------|-------|------|
| GET   | /ai/analyze | `startDate`, `endDate` | Analiza wszystkich metryk i rekomendacje |
| GET   | /ai/analyze/sleep | `startDate`, `endDate` | Analiza tylko snu |
| GET   | /ai/analyze/activity | `startDate`, `endDate` | Analiza tylko aktywności |
| GET   | /ai/analyze/meal | `startDate`, `endDate` | Analiza tylko posiłków |
