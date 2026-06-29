# Lost And Found

Et læringsprosjekt i ASP.NET Core Web API der jeg bygger en testbar hittegodsløsning med TDD, tydelig skille mellom domenelogikk og HTTP-lim, og et eget application service/use-case-lag. API-et dokumenteres med Swagger/OpenAPI, testes med xUnit, og kjøres lokalt sammen med PostgreSQL via Docker Compose for en enkel og konsistent utviklingsflyt.

## Starting TODO

- [x] Opprett og skriv første domene-tester for `FoundItem` (rød -> grønn -> refaktor).
- [x] Implementer grunnleggende domenelogikk for statusflyt: `Available` -> `Claimed` -> `Returned`.
- [x] Definer MVP-felter i domenemodellen: `Id`, `Title`, `Description`, `Category`, `FoundLocation`, `DateFound`, `Status`, `ClaimedBy`, `DateClaimedAt`, `DateReturnedAt`.
- [x] Lag et testbart application service/use-case-lag for opprettelse og statusendringer.
- [x] Opprett DTO-er og validering for inn/ut-data i API-et.
- [ ] Implementer minimale endpoints med riktige statuskoder og feilhåndtering.
- [ ] Aktiver Swagger/OpenAPI og beskriv endepunktene.
- [ ] Sett opp `docker-compose` for API + PostgreSQL med miljøvariabler, volume, port-mapping og `depends_on`/healthcheck.

## Notes

- Remember to run dotnet clean before testing to avoid caching issues
