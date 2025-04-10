# Use the .NET 9 Preview SDK for building
FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
WORKDIR /src

# Copy the full SAFER.API folder
COPY . ./

#restore
RUN dotnet restore SAFER.API.csproj
RUN dotnet publish SAFER.API.csproj -c Release -o /app/publish

# Use the .NET 9 Preview ASP.NET runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SAFER.API.dll"]
