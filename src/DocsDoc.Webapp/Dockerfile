FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DocsDoc.Webapp/DocsDoc.Webapp.csproj", "DocsDoc.Webapp/"]
RUN dotnet restore "DocsDoc.Webapp/DocsDoc.Webapp.csproj"
COPY . .
WORKDIR "/src/DocsDoc.Webapp"
RUN dotnet build "DocsDoc.Webapp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DocsDoc.Webapp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DocsDoc.Webapp.dll"]
