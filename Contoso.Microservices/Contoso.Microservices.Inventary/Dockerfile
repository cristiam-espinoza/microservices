FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

# STAGE01 - Build application and its dependencies
FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Contoso.Microservices.Inventary/Contoso.Microservices.Inventary.csproj", "Contoso.Microservices.Inventary/"]
RUN dotnet restore "Contoso.Microservices.Inventary/Contoso.Microservices.Inventary.csproj"
COPY . .
WORKDIR "/src/Contoso.Microservices.Inventary"
RUN dotnet build "Contoso.Microservices.Inventary.csproj" -c Release -o /app

# STAGE02 - Publish the application
FROM build AS publish
RUN dotnet publish "Contoso.Microservices.Inventary.csproj" -c Release -o /app

# STAGE03 - Create the final image
FROM base AS final
WORKDIR /app
LABEL Author="Cristiam Espinoza"
LABEL Maintainer="devops labs"
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Contoso.Microservices.Inventary.dll"]