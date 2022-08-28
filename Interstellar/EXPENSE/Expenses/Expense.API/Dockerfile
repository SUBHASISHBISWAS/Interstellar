#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EXPENSE/Expenses/Expense.API/Expense.API.csproj", "EXPENSE/Expenses/Expense.API/"]
COPY ["EXPENSE/Expenses/Expense.Application/Expense.Application.csproj", "EXPENSE/Expenses/Expense.Application/"]
COPY ["EXPENSE/Expenses/Expense.Domain/Expense.Domain.csproj", "EXPENSE/Expenses/Expense.Domain/"]
COPY ["EXPENSE/Expenses/Expense.Infrastructure/Expense.Infrastructure.csproj", "EXPENSE/Expenses/Expense.Infrastructure/"]
RUN dotnet restore "EXPENSE/Expenses/Expense.API/Expense.API.csproj"
COPY . .
WORKDIR "/src/EXPENSE/Expenses/Expense.API"
RUN dotnet build "Expense.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Expense.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Expense.API.dll"]