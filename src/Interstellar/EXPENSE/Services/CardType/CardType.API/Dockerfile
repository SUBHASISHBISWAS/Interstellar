#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EXPENSE/Services/CardType/CardType.API/CardType.API.csproj", "EXPENSE/Services/CardType/CardType.API/"]
COPY ["EXPENSE/Services/CardType/CardType.Application/CardType.Application.csproj", "EXPENSE/Services/CardType/CardType.Application/"]
COPY ["EXPENSE/Services/CardType/CardType.Domain/CardType.Domain.csproj", "EXPENSE/Services/CardType/CardType.Domain/"]
COPY ["EXPENSE/Services/CardType/CardType.Infrastructure/CardType.Infrastructure.csproj", "EXPENSE/Services/CardType/CardType.Infrastructure/"]
RUN dotnet restore "EXPENSE/Services/CardType/CardType.API/CardType.API.csproj"
COPY . .
WORKDIR "/src/EXPENSE/Services/CardType/CardType.API"
RUN dotnet build "CardType.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CardType.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CardType.API.dll"]