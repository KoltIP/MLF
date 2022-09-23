#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Systems/Api/PetProject.Api/PetProject.Api.csproj", "Systems/Api/PetProject.Api/"]
COPY ["Services/PetProject.TypeServices/PetProject.TypeServices.csproj", "Services/PetProject.TypeServices/"]
COPY ["Shared/PetProject.Shared.Common/PetProject.Shared.Common.csproj", "Shared/PetProject.Shared.Common/"]
COPY ["Data/PetProject.Db.Entities/PetProject.Db.Entities.csproj", "Data/PetProject.Db.Entities/"]
COPY ["Data/PetProject.Db.Context/PetProject.Db.Context.csproj", "Data/PetProject.Db.Context/"]
COPY ["Services/PetProject.PetServices/PetProject.PetServices.csproj", "Services/PetProject.PetServices/"]
COPY ["Services/PetProject.BreedServices/PetProject.BreedServices.csproj", "Services/PetProject.BreedServices/"]
COPY ["Services/PetProject.RabbitMqService/PetProject.RabbitMqService.csproj", "Services/PetProject.RabbitMqService/"]
COPY ["Services/PetProject.Settings/PetProject.Settings.csproj", "Services/PetProject.Settings/"]
COPY ["Services/PetProject.UserAccountService/PetProject.UserAccountService.csproj", "Services/PetProject.UserAccountService/"]
COPY ["Systems/Web/PetProject.Web/PetProject.Web.csproj", "Systems/Web/PetProject.Web/"]
COPY ["Services/PetProject.EmailService/PetProject.EmailService.csproj", "Services/PetProject.EmailService/"]
COPY ["Services/PetProject.AdvertisementServices/PetProject.AdvertisementServices.csproj", "Services/PetProject.AdvertisementServices/"]
COPY ["Services/PetProject.ColorServices/PetProject.ColorServices.csproj", "Services/PetProject.ColorServices/"]
RUN dotnet restore "Systems/Api/PetProject.Api/PetProject.Api.csproj"
COPY . .
WORKDIR "/src/Systems/Api/PetProject.Api"
RUN dotnet build "PetProject.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PetProject.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PetProject.Api.dll"]