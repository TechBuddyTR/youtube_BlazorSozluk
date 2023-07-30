#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Projections/BlazorSozluk.Projections.User/BlazorSozluk.Projections.UserService.csproj", "src/Projections/BlazorSozluk.Projections.User/"]
COPY ["src/Common/BlazorSozluk.Common/BlazorSozluk.Common.csproj", "src/Common/BlazorSozluk.Common/"]
RUN dotnet restore "src/Projections/BlazorSozluk.Projections.User/BlazorSozluk.Projections.UserService.csproj"
COPY . .
WORKDIR "/src/src/Projections/BlazorSozluk.Projections.User"
RUN dotnet build "BlazorSozluk.Projections.UserService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorSozluk.Projections.UserService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorSozluk.Projections.UserService.dll"]
