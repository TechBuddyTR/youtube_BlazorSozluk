FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
COPY . ./
#RUN dotnet publish -c Release -o output
RUN dotnet publish "src/Clients/BlazorWeb/BlazorSozluk.WebApp/BlazorSozluk.WebApp.csproj" -c Release -o /app/build

FROM nginx:alpine
WORKDIR /var/www/web
COPY --from=build-env /app/build/wwwroot .
#COPY src/Clients/BlazorWebApp/WebApp/nginx.conf /etc/nginx/nginx.conf

# --------

#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
#EXPOSE 80
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["src/Clients/BlazorWeb/BlazorSozluk.WebApp/BlazorSozluk.WebApp.csproj", "src/Clients/BlazorWeb/BlazorSozluk.WebApp"]
#RUN dotnet restore "src/Clients/BlazorWeb/BlazorSozluk.WebApp/BlazorSozluk.WebApp.csproj"
#COPY . .
#WORKDIR "/src/Clients/BlazorWeb/BlazorSozluk.WebApp"
#RUN dotnet build "BlazorSozluk.WebApp.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "BlazorSozluk.WebApp.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "BlazorSozluk.WebApp.dll"]
#
#FROM nginx:alpine AS final
#WORKDIR /usr/share/nginx/html
##Copy from Environment(build/publish)
#COPY --from=publish app/publish/wwwroot . 

# --------

#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
#EXPOSE 80
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["src/Clients/BlazorWeb/BlazorSozluk.WebApp/BlazorSozluk.WebApp.csproj", "src/Clients/BlazorWeb/BlazorSozluk.WebApp"]
#RUN dotnet restore "src/Clients/BlazorWeb/BlazorSozluk.WebApp/BlazorSozluk.WebApp.csproj"
#COPY . .
#WORKDIR "/src/Clients/BlazorWeb/BlazorSozluk.WebApp"
#RUN dotnet build "BlazorSozluk.WebApp.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "BlazorSozluk.WebApp.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "BlazorSozluk.WebApp.dll"]
#
#FROM nginx:alpine AS final
#WORKDIR /usr/share/nginx/html
##Copy from Environment(build/publish)
#COPY --from=publish app/publish/wwwroot . 
