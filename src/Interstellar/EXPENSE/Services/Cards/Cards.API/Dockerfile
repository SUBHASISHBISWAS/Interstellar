#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EXPENSE/Services/Cards/Cards.API/Cards.API.csproj", "EXPENSE/Services/Cards/Cards.API/"]
COPY ["EXPENSE/Services/Cards/Cards.Infrastructure/Cards.Infrastructure.csproj", "EXPENSE/Services/Cards/Cards.Infrastructure/"]
COPY ["EXPENSE/Services/Cards/Cards.Application/Cards.Application.csproj", "EXPENSE/Services/Cards/Cards.Application/"]
COPY ["EXPENSE/Services/Cards/Cards.Domain/Cards.Domain.csproj", "EXPENSE/Services/Cards/Cards.Domain/"]
RUN dotnet restore "EXPENSE/Services/Cards/Cards.API/Cards.API.csproj"
COPY . .
WORKDIR "/src/EXPENSE/Services/Cards/Cards.API"
RUN dotnet build "Cards.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cards.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cards.API.dll"]
