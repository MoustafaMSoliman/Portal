FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY *.sln ./
COPY Portal.Api/*.csproj ./Portal.Api/
COPY Portal.Application/*.csproj ./Portal.Application/
COPY Portal.Domain/*.csproj ./Portal.Domain/
COPY Portal.Conttracts/*.csproj ./Portal.Conttracts/
COPY Portal.Infrastructure/*.csproj ./Portal.Infrastructure/

RUN dotnet restore
COPY . ./
RUN dotnet build -c Release -o /app/build
RUN dotnet publish Portal.Api/Portal.Api.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 80

ENTRYPOINT ["dotnet", "Portal.Api.dll"]