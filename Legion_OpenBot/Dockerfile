FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Legion_OpenBot/Legion_OpenBot.csproj", "Legion_OpenBot/"]
RUN dotnet restore "Legion_OpenBot/Legion_OpenBot.csproj"
COPY . .
WORKDIR "/src/Legion_OpenBot"
RUN dotnet build "Legion_OpenBot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Legion_OpenBot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Legion_OpenBot.dll"]
