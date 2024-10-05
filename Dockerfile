FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /App

COPY Portal.sln ./
COPY ["Portal.Api/Portal.Api.csproj","Portal.Api/"] 
COPY ["Portal.Application/Portal.Application.csproj","Portal.Application/"] 
COPY ["Portal.Domain/Portal.Domain.csproj","Portal.Domain/"] 
COPY ["Portal.Conttracts/Portal.Conttracts.csproj","Portal.Conttracts/"] 
COPY ["Portal.Infrastructure/Portal.Infrastructure.csproj","Portal.Infrastructure/"] 

RUN dotnet restore 'Portal.Api/Portal.Api.csproj'
RUN dotnet restore 'Portal.Application/Portal.Application.csproj'
RUN dotnet restore 'Portal.Domain/Portal.Domain.csproj'
RUN dotnet restore 'Portal.Conttracts/Portal.Conttracts.csproj'
RUN dotnet restore 'Portal.Infrastructure/Portal.Infrastructure.csproj'
RUN dotnet restore 'Portal.sln'

COPY . ./
WORKDIR /App
RUN dotnet build 'Portal.sln' -c Release -o /App/build
RUN dotnet build 'Portal.Api/Portal.Api.csproj' -c Release -o /App/build
RUN dotnet build 'Portal.Application/Portal.Application.csproj' -c Release -o /App/build
RUN dotnet build 'Portal.Domain/Portal.Domain.csproj' -c Release -o /App/build
RUN dotnet build 'Portal.Conttracts/Portal.Conttracts.csproj' -c Release -o /App/build
RUN dotnet build 'Portal.Infrastructure/Portal.Infrastructure.csproj' -c Release -o /App/build



FROM build as publish
RUN dotnet publish 'Portal.sln' -c Release -o /App/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=publish /App/publish .
ENTRYPOINT ["dotnet", "Portal.Api.dll"]

