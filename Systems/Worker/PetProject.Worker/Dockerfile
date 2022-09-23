#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Systems/Worker/PetProject.Worker/PetProject.Worker.csproj", "Systems/Worker/PetProject.Worker/"]
COPY ["Services/PetProject.RabbitMqService/PetProject.RabbitMqService.csproj", "Services/PetProject.RabbitMqService/"]
COPY ["Services/PetProject.Settings/PetProject.Settings.csproj", "Services/PetProject.Settings/"]
COPY ["Services/PetProject.EmailService/PetProject.EmailService.csproj", "Services/PetProject.EmailService/"]
COPY ["Data/PetProject.Db.Context/PetProject.Db.Context.csproj", "Data/PetProject.Db.Context/"]
COPY ["Data/PetProject.Db.Entities/PetProject.Db.Entities.csproj", "Data/PetProject.Db.Entities/"]
RUN dotnet restore "Systems/Worker/PetProject.Worker/PetProject.Worker.csproj"
COPY . .
WORKDIR "/src/Systems/Worker/PetProject.Worker"
RUN dotnet build "PetProject.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PetProject.Worker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PetProject.Worker.dll"]