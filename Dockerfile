# Projen .NET 9 ise 9.0, .NET 8 ise 8.0 yap (Çoğunlukla güncel kurulumlar 9 veya 8'dir)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Proje dosyasını kopyala ve restore et
COPY ["WorkoutTrackerApi.csproj", "./"]
RUN dotnet restore "WorkoutTrackerApi.csproj"

# Tüm dosyaları kopyala ve publish al
COPY . .
RUN dotnet publish "WorkoutTrackerApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "WorkoutTrackerApi.dll"]