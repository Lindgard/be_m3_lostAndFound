FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["LostAndFound.API/LostAndFound.API.csproj", "LostAndFound.API/"]
COPY ["LostAndFound.Domain/LostAndFoundService.csproj", "LostAndFound.Domain/"]
RUN dotnet restore "LostAndFound.API/LostAndFound.API.csproj"

COPY . .
RUN dotnet publish "LostAndFound.API/LostAndFound.API.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "LostAndFound.API.dll"]