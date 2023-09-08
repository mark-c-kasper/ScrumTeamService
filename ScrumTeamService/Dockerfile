FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ScrumTeamService/ScrumTeamService.csproj", "ScrumTeamService/"]
RUN dotnet restore "ScrumTeamService/ScrumTeamService.csproj"
COPY . .
WORKDIR "/src/ScrumTeamService"
RUN dotnet build "ScrumTeamService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ScrumTeamService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ScrumTeamService.dll"]
