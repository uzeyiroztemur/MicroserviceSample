#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["UserPortalService/UserPortalService.RestApi/UserPortalService.RestApi.csproj", "UserPortalService/UserPortalService.RestApi/"]
#COPY ["UserPortalService/UserPortalService.Business/UserPortalService.Business.csproj", "UserPortalService/UserPortalService.Business/"]
#COPY ["UserPortalService/UserPortalService.DataAccess/UserPortalService.DataAccess.csproj", "UserPortalService/UserPortalService.DataAccess/"]
#COPY ["UserPortalService/UserPortalService.Entities/UserPortalService.Entities.csproj", "UserPortalService/UserPortalService.Entities/"]
#COPY ["Common/Microservice.Core/Microservice.Core.csproj", "Common/Microservice.Core/"]
#RUN dotnet restore "UserPortalService/UserPortalService.RestApi/UserPortalService.RestApi.csproj"
#COPY . .
#WORKDIR "/src/UserPortalService/UserPortalService.RestApi"
#RUN dotnet build "UserPortalService.RestApi.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "UserPortalService.RestApi.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "UserPortalService.RestApi.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UserPortalService/UserPortalService.RestApi/UserPortalService.RestApi.csproj", "UserPortalService/UserPortalService.RestApi/"]
COPY ["UserPortalService/UserPortalService.Business/UserPortalService.Business.csproj", "UserPortalService/UserPortalService.Business/"]
COPY ["UserPortalService/UserPortalService.DataAccess/UserPortalService.DataAccess.csproj", "UserPortalService/UserPortalService.DataAccess/"]
COPY ["UserPortalService/UserPortalService.Entities/UserPortalService.Entities.csproj", "UserPortalService/UserPortalService.Entities/"]
COPY ["Common/Microservice.Core/Microservice.Core.csproj", "Common/Microservice.Core/"]
RUN dotnet restore "UserPortalService/UserPortalService.RestApi/UserPortalService.RestApi.csproj"
COPY . .
RUN dotnet publish "UserPortalService.RestApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY bin/Release/net6.0/publish /app/
ENTRYPOINT ["dotnet", "UserPortalService.RestApi.dll"]
