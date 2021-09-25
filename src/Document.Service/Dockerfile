FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DocsDoc.Documents.Service.csproj", "Document.Service/"]
RUN dotnet restore "DocsDoc.Documents.Service.csproj"
COPY . .
WORKDIR "/src/Document.Service"
RUN dotnet build "DocsDoc.Documents.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DocsDoc.Documents.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DocsDoc.Documents.Service.dll"]