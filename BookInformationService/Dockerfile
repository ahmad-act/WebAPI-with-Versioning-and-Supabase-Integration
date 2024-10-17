# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App

# Copy the build output from the build stage
COPY --from=build-env /App/out .

# Use a build argument to set the environment variable
ARG ENVIRONMENT=Production
ENV ASPNETCORE_ENVIRONMENT=${ENVIRONMENT}

ENTRYPOINT ["dotnet", "BookInformationService.dll"]
