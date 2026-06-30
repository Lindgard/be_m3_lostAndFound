# Lost And Found

A learning project built with ASP.NET Core Web API implementing a testable lost-and-found solution. The project follows TDD principles with a clear separation between domain logic and HTTP layer, and includes a dedicated application service/use-case layer. The API is documented with Swagger/OpenAPI, tested with xUnit, and runs locally alongside PostgreSQL via Docker Compose.

## Project Structure

```txt
be_m3_lostAndFound/
├── LostAndFound.Api/       # ASP.NET Core Web API — controllers, DTOs, Program.cs
├── LostAndFound.Domain/    # Domain models, application services and use-case logic
├── LostAndFound.Tests/     # xUnit test project
├── Dockerfile
└── docker-compose.yaml
```

## Item Status Flow

```txt
Available → Claimed → Returned
```

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Docker & Docker Compose](https://docs.docker.com/get-docker/)

## Running with Docker Compose (recommended)

```bash
docker compose up --build
```

| Service | URL |
| --------- | ----- |
| API | <http://localhost:5000> |
| Swagger UI | <http://localhost:5000/swagger> |

```bash
# Stop containers
docker compose down

# Stop and remove volumes (clears database)
docker compose down -v
```

## Running Locally (without Docker)

Update `LostAndFound.Api/appsettings.Development.json` with your local PostgreSQL connection string, then:

```bash
cd LostAndFound.Api
dotnet run
```

## Running Tests

```bash
dotnet clean
dotnet test
```

## Starting TODO

- [x] Opprett og skriv første domene-tester for `FoundItem` (rød -> grønn -> refaktor).
- [x] Implementer grunnleggende domenelogikk for statusflyt: `Available` -> `Claimed` -> `Returned`.
- [x] Definer MVP-felter i domenemodellen: `Id`, `Title`, `Description`, `Category`, `FoundLocation`, `DateFound`, `Status`, `ClaimedBy`, `DateClaimedAt`, `DateReturnedAt`.
- [x] Lag et testbart application service/use-case-lag for opprettelse og statusendringer.
- [x] Opprett DTO-er og validering for inn/ut-data i API-et.
- [x] Implementer minimale endpoints med riktige statuskoder og feilhåndtering.
- [x] Aktiver Swagger/OpenAPI og beskriv endepunktene.
- [x] Sett opp `docker-compose` for API + PostgreSQL med miljøvariabler, volume, port-mapping og `depends_on`/healthcheck.

## Notes

- Remember to run dotnet clean before testing to avoid caching issues
