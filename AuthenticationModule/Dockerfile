FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /App

COPY ./*.csproj ./
# Restore as distinct layers
RUN dotnet restore
# Copy everything
COPY . ./
# Build and publish a release
RUN dotnet publish -c Release -o AuthenticationModule

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build /App/AuthenticationModule .
ENTRYPOINT ["dotnet", "AuthenticationModule.dll"]