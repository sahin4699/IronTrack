# .NET 10 SDK
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["WorkoutTrackerApi.csproj", "./"]
RUN dotnet restore "WorkoutTrackerApi.csproj"

COPY . .
RUN dotnet publish "WorkoutTrackerApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# .NET 10 Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "WorkoutTrackerApi.dll"]