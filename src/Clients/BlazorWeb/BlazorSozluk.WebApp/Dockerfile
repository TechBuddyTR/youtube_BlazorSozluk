FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
COPY . ./
RUN dotnet publish "src/Clients/BlazorWeb/BlazorSozluk.WebApp/BlazorSozluk.WebApp.csproj" -c Release -o output

FROM nginx:alpine
WORKDIR /var/www/web
COPY --from=build-env /app/output/wwwroot .
COPY "src/Clients/BlazorWeb/BlazorSozluk.WebApp/nginx.conf" /etc/nginx/nginx.conf

