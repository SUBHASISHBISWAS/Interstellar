#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EXPENSE/Cards/Cards.API/Cards.API.csproj", "EXPENSE/Cards/Cards.API/"]
COPY ["EXPENSE/Cards/Cards.Infrastructure/Cards.Infrastructure.csproj", "EXPENSE/Cards/Cards.Infrastructure/"]
COPY ["EXPENSE/Cards/Cards.Application/Cards.Application.csproj", "EXPENSE/Cards/Cards.Application/"]
COPY ["EXPENSE/Cards/Cards.Domain/Cards.Domain.csproj", "EXPENSE/Cards/Cards.Domain/"]
RUN dotnet restore "EXPENSE/Cards/Cards.API/Cards.API.csproj"
COPY . .
WORKDIR "/src/EXPENSE/Cards/Cards.API"
RUN dotnet build "Cards.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cards.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cards.API.dll"]