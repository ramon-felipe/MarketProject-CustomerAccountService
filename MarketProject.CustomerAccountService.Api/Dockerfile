#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MarketProject.CustomerAccountService.Api/MarketProject.CustomerAccountService.Api.csproj", "MarketProject.CustomerAccountService.Api/"]
COPY ["MarketProject.CustomerAccountService.Domain/MarketProject.CustomerAccountService.Domain.csproj", "MarketProject.CustomerAccountService.Domain/"]
COPY ["MarketProject.CustomerAccountService.Application/MarketProject.CustomerAccountService.Application.csproj", "MarketProject.CustomerAccountService.Application/"]
RUN dotnet restore "MarketProject.CustomerAccountService.Api/MarketProject.CustomerAccountService.Api.csproj"
COPY . .
WORKDIR "/src/MarketProject.CustomerAccountService.Api"
RUN dotnet build "MarketProject.CustomerAccountService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MarketProject.CustomerAccountService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MarketProject.CustomerAccountService.Api.dll"]