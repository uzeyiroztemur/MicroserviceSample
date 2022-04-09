#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["ManagementService/ManagementService.RestApi/ManagementService.RestApi.csproj", "ManagementService/ManagementService.RestApi/"]
#RUN dotnet restore "ManagementService/ManagementService.RestApi/ManagementService.RestApi.csproj"
#COPY . .
#WORKDIR "/src/ManagementService/ManagementService.RestApi"
#RUN dotnet build "ManagementService.RestApi.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "ManagementService.RestApi.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "ManagementService.RestApi.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ManagementService/ManagementService.RestApi/ManagementService.RestApi.csproj", "ManagementService/ManagementService.RestApi/"]
#COPY ["YTD.Dpr/YTD.Dpr.csproj", "YTD.Dpr/"]
#COPY ["YTD.DataAccesss/YTD.DataAccesss.csproj", "YTD.DataAccesss/"]
#COPY ["YY.Core/YY.Core.csproj", "YY.Core/"]
#COPY ["YTD.Business/YTD.Business.csproj", "YTD.Business/"]
RUN dotnet restore "ManagementService/ManagementService.RestApi/ManagementService.RestApi.csproj"
COPY . .
RUN dotnet publish "ManagementService.RestApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY bin/Release/net6.0/publish /app/
ENTRYPOINT ["dotnet", "ManagementService.RestApi.dll"]
