#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Systems/Identity/PetProject.Identity/PetProject.Identity.csproj", "Systems/Identity/PetProject.Identity/"]
COPY ["Shared/PetProject.Shared.Common/PetProject.Shared.Common.csproj", "Shared/PetProject.Shared.Common/"]
COPY ["Services/PetProject.Settings/PetProject.Settings.csproj", "Services/PetProject.Settings/"]
COPY ["Data/PetProject.Db.Context/PetProject.Db.Context.csproj", "Data/PetProject.Db.Context/"]
COPY ["Data/PetProject.Db.Entities/PetProject.Db.Entities.csproj", "Data/PetProject.Db.Entities/"]
RUN dotnet restore "Systems/Identity/PetProject.Identity/PetProject.Identity.csproj"
COPY . .
WORKDIR "/src/Systems/Identity/PetProject.Identity"
RUN dotnet build "PetProject.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PetProject.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PetProject.Identity.dll"]