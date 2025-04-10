# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["./api gateways/NSE.BFF.Compras/NSE.BFF.Compras.csproj", "api gateways/NSE.BFF.Compras/"]
COPY ["./building blocks/NSE.Core/NSE.Core.csproj", "building blocks/NSE.WebAPI.Core/"]
COPY ["./building blocks/NSE.WebAPI.Core/NSE.WebAPI.Core.csproj", "building blocks/NSE.WebAPI.Core/"]
COPY ["./building blocks/NSE.MessageBus/NSE.MessageBus.csproj", "building blocks/NSE.MessageBus/"]

RUN dotnet restore "api gateways/NSE.BFF.Compras/NSE.BFF.Compras.csproj"
COPY . .
WORKDIR "api gateways/NSE.BFF.Compras"
RUN dotnet build "NSE.BFF.Compras.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NSE.BFF.Compras.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NSE.BFF.Compras.dll"]