FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["gab-2019-app/gab-2019-app.csproj", "gab-2019-app/"]
RUN dotnet restore "gab-2019-app/gab-2019-app.csproj"
COPY . .
WORKDIR "/src/gab-2019-app"
RUN dotnet build "gab-2019-app.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "gab-2019-app.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "gab-2019-app.dll"]