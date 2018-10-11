# FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base --- this particular version is Windows containers only
FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

# FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build --- this particular version is Windows containers only
FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY NeoMoviesCore/NeoMoviesCore.csproj NeoMoviesCore/
RUN dotnet restore NeoMoviesCore/NeoMoviesCore.csproj
COPY . .
WORKDIR /src/NeoMoviesCore
RUN dotnet build NeoMoviesCore.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish NeoMoviesCore.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NeoMoviesCore.dll"]
