#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Api/WebApi/BlazorSozluk.Api.WebApi/BlazorSozluk.Api.WebApi.csproj", "src/Api/WebApi/BlazorSozluk.Api.WebApi/"]
COPY ["src/Api/Infrastructure/BlazorSozluk.Infrastructure.Persistence/BlazorSozluk.Api.Infrastructure.Persistence.csproj", "src/Api/Infrastructure/BlazorSozluk.Infrastructure.Persistence/"]
COPY ["src/Api/Core/BlazorSozluk.Api.Application/BlazorSozluk.Api.Application.csproj", "src/Api/Core/BlazorSozluk.Api.Application/"]
COPY ["src/Api/Core/BlazorSozluk.Api.Domain/BlazorSozluk.Api.Domain.csproj", "src/Api/Core/BlazorSozluk.Api.Domain/"]
COPY ["src/Common/BlazorSozluk.Common/BlazorSozluk.Common.csproj", "src/Common/BlazorSozluk.Common/"]
RUN dotnet restore "src/Api/WebApi/BlazorSozluk.Api.WebApi/BlazorSozluk.Api.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Api/WebApi/BlazorSozluk.Api.WebApi"
RUN dotnet build "BlazorSozluk.Api.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorSozluk.Api.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorSozluk.Api.WebApi.dll"]