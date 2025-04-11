#build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
WORKDIR /src
COPY SAFER.API/*.csproj ./
RUN dotnet restore SAFER.API.csproj
COPY . ./
RUN dotnet publish SAFER.API.csproj -c Release -o /app/publish

#runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SAFER.API.dll"]