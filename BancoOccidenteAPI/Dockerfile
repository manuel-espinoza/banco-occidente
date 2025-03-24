FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["BancoOccidente.WebApi/BancoOccidente.WebApi.csproj", "BancoOccidente.WebApi/"]
COPY ["BancoOccidente.DataAccess/BancoOccidente.DataAccess.csproj", "BancoOccidente.DataAccess/"]
COPY ["BancoOccidente.Service/BancoOccidente.Service.csproj", "BancoOccidente.Service/"]

RUN dotnet restore "./BancoOccidente.WebApi/BancoOccidente.WebApi.csproj"


COPY . .

WORKDIR "/src/BancoOccidente.WebApi"
RUN dotnet build "./BancoOccidente.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BancoOccidente.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BancoOccidente.WebApi.dll"]