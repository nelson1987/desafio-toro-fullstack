#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
# FROM centos:7 AS base

# # Add Microsoft package repository and install ASP.NET Core
# RUN rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm \
    # && yum install -y aspnetcore-runtime-6.0

# # Ensure we listen on any IP Address 
# ENV DOTNET_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/ToroChallenge.Api/ToroChallenge.Api.csproj", "src/ToroChallenge.Api/"]
COPY ["src/ToroChallenge.Application/ToroChallenge.Application.csproj", "src/ToroChallenge.Application/"]
COPY ["src/ToroChallenge.Domain/ToroChallenge.Domain.csproj", "src/ToroChallenge.Domain/"]
COPY ["src/ToroChallenge.Data/ToroChallenge.Data.csproj", "src/ToroChallenge.Data/"]
COPY ["src/ToroChallenge.Service/ToroChallenge.Service.csproj", "src/ToroChallenge.Service/"]
RUN dotnet restore "src/ToroChallenge.Api/ToroChallenge.Api.csproj"
COPY . .
WORKDIR "/src/src/ToroChallenge.Api"
RUN dotnet build "ToroChallenge.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToroChallenge.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToroChallenge.Api.dll"]

#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src

#COPY ["src/ToroChallenge.Api/ToroChallenge.Api.csproj", "src/ToroChallenge.Api/"]
#COPY ["src/ToroChallenge.Application/ToroChallenge.Application.csproj", "src/ToroChallenge.Application/"]
#COPY ["src/ToroChallenge.Domain/ToroChallenge.Domain.csproj", "src/ToroChallenge.Domain/"]
#COPY ["src/ToroChallenge.Data/ToroChallenge.Data.csproj", "src/ToroChallenge.Data/"]
#COPY ["src/ToroChallenge.Service/ToroChallenge.Service.csproj", "src/ToroChallenge.Service/"]
#RUN dotnet restore "src/ToroChallenge.Api/ToroChallenge.Api.csproj"
#COPY . .
#WORKDIR "/src/ToroChallenge.Api/"
#RUN ls
#RUN dotnet build "ToroChallenge.Api.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "ToroChallenge.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "ToroChallenge.Api.dll"]

##See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
#
##FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
##WORKDIR /app
##EXPOSE 80
##EXPOSE 443
##
##FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
##WORKDIR /src
##COPY ["src/ToroChallenge.Api/ToroChallenge.Api.csproj", "src/ToroChallenge.Api/"]
##COPY ["src/ToroChallenge.Application/ToroChallenge.Application.csproj", "src/ToroChallenge.Application/"]
##COPY ["src/ToroChallenge.Domain/ToroChallenge.Domain.csproj", "src/ToroChallenge.Domain/"]
##COPY ["src/ToroChallenge.Data/ToroChallenge.Data.csproj", "src/ToroChallenge.Data/"]
##COPY ["src/ToroChallenge.Service/ToroChallenge.Service.csproj", "src/ToroChallenge.Service/"]
##RUN dotnet restore "src/ToroChallenge.Api/ToroChallenge.Api.csproj"
##COPY . .
##WORKDIR "/src/src/ToroChallenge.Api"
##RUN dotnet build "ToroChallenge.Api.csproj" -c Release -o /app/build
##
##FROM build AS publish
##RUN dotnet publish "ToroChallenge.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false
##
##FROM base AS final
##WORKDIR /app
##COPY --from=publish /app/publish .
##ENTRYPOINT ["dotnet", "ToroChallenge.Api.dll"]
#
#FROM mcr.microsoft.com/dotnet/aspnet:6.0 as base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
##COPY "ToroChallenge.Api.csproj" "./"
##COPY ["ToroChallenge.Api/ToroChallenge.Api.csproj", "./"]
##COPY ["ToroChallenge.Application/ToroChallenge.Application.csproj", "./"]
##COPY ["ToroChallenge.Domain/ToroChallenge.Domain.csproj", "./"]
##COPY ["ToroChallenge.Data/ToroChallenge.Data.csproj", "./"]
#COPY "*.csproj" "./"
#RUN dotnet restore "./ToroChallenge.Api.csproj"
#COPY . .
#RUN ls
#RUN dotnet build "./ToroChallenge.Api.csproj" -c Release -o /app
#
#FROM build AS publish
#RUN dotnet publish "./ToroChallenge.Api.csproj" -c Release -o /app
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app .
#ENTRYPOINT ["dotnet", "ToroChallenge.Api.dll"]
#
#
##FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
##WORKDIR /app
##
### Copiar csproj e restaurar dependencias
##COPY *.csproj ./
##RUN dotnet restore
##
### Build da aplicacao
##COPY ./ ./
##RUN dotnet publish -c Release
##
### Build da imagem
##FROM mcr.microsoft.com/dotnet/sdk:6.0
##WORKDIR /app
##COPY --from=build-env /app/out .
##ENTRYPOINT ["dotnet", "SiteHeroisMarvel.dll"