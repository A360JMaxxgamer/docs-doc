#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Document.Service/DocsDoc.Docmuent.Service/DocsDoc.Docmuent.Service.csproj", "Document.Service/DocsDoc.Docmuent.Service/"]
RUN dotnet restore "Document.Service/DocsDoc.Docmuent.Service/DocsDoc.Docmuent.Service.csproj"
COPY . .
WORKDIR "/src/Document.Service/DocsDoc.Docmuent.Service"
RUN dotnet build "DocsDoc.Docmuent.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DocsDoc.Docmuent.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DocsDoc.Docmuent.Service.dll"]