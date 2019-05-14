FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Contoso.Microservices.Inventary/Contoso.Microservices.Inventary.csproj", "Contoso.Microservices.Inventary/"]
RUN dotnet restore "Contoso.Microservices.Inventary/Contoso.Microservices.Inventary.csproj"
COPY . .
WORKDIR "/src/Contoso.Microservices.Inventary"
RUN dotnet build "Contoso.Microservices.Inventary.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Contoso.Microservices.Inventary.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Contoso.Microservices.Inventary.dll"]