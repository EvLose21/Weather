#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WeatherApi.com/WeatherApi.com.csproj", "WeatherApi.com/"]
COPY ["WeatherApi.Library/WeatherApi.Library.csproj", "WeatherApi.Library/"]
RUN dotnet restore "WeatherApi.com/WeatherApi.com.csproj"
COPY . .
WORKDIR "/src/WeatherApi.com"
RUN dotnet build "WeatherApi.com.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WeatherApi.com.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeatherApi.com.dll"]