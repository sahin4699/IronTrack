# Hem .NET 8 hem 9 ile uyumlu SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Proje dosyasını kopyala ve restore et
COPY ["WorkoutTrackerApi.csproj", "./"]
RUN dotnet restore "WorkoutTrackerApi.csproj"

# Kalan tüm dosyaları al ve release derle
COPY . .
RUN dotnet publish "WorkoutTrackerApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Çalışma ortamı (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "WorkoutTrackerApi.dll"]