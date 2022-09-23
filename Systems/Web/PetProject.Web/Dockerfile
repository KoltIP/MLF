FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Systems/Web/PetProject.Web/PetProject.Web.csproj", "Systems/Web/PetProject.Web/PetProject.Web.csproj"]
RUN dotnet restore "Systems/Web/PetProject.Web/PetProject.Web.csproj"
COPY . .
WORKDIR "/src/Systems/Web/PetProject.Web"
RUN dotnet build "PetProject.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PetProject.Web.csproj" -c Release -o /app/publish

FROM nginx:alpine
WORKDIR /var/www/web

COPY --from=publish /app/publish/wwwroot .
COPY Systems/Web/PetProject.Web/nginx.conf /etc/nginx/nginx.conf
EXPOSE 80