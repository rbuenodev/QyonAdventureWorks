#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Application/API/API.csproj", "Application/API/"]
COPY ["Domain/Domain/Domain.csproj", "Domain/Domain/"]
COPY ["Infra/Data/Data.csproj", "Infra/Data/"]
COPY ["Service/Service/Service.csproj", "Service/Service/"]
RUN dotnet restore "Application/API/API.csproj"
RUN dotnet dev-certs https
COPY . .
WORKDIR "/src/Application/API"
RUN dotnet build "API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build /root/.dotnet/corefx/cryptography/x509stores/my/* /root/.dotnet/corefx/cryptography/x509stores/my/
ENTRYPOINT ["dotnet", "API.dll"]