FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["CustomSkill.API/CustomSkill.API.csproj", "CustomSkill.API/"]
RUN dotnet restore "CustomSkill.API/CustomSkill.API.csproj"
COPY . .
WORKDIR "/src/CustomSkill.API"
RUN dotnet build "CustomSkill.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CustomSkill.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CustomSkill.API.dll"]