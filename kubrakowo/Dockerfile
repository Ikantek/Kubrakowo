#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["kubrakowo/Kubrakowo.WebApp.csproj", "kubrakowo/"]
RUN dotnet restore "kubrakowo/Kubrakowo.WebApp.csproj"
COPY . .
WORKDIR "/src/kubrakowo"
RUN dotnet build "Kubrakowo.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kubrakowo.WebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kubrakowo.WebApp.dll"]