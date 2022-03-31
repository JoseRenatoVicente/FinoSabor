#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/FinoSabor.Services.Api/FinoSabor.Services.Api.csproj", "src/FinoSabor.Services.Api/"]
COPY ["src/FinoSabor.Domain/FinoSabor.Domain.csproj", "src/FinoSabor.Domain/"]
COPY ["src/FinoSabor.Infra.CrossCutting.Identity/FinoSabor.Infra.CrossCutting.Identity.csproj", "src/FinoSabor.Infra.CrossCutting.Identity/"]
COPY ["src/FinoSabor.Application/FinoSabor.Application.csproj", "src/FinoSabor.Application/"]
COPY ["src/FinoSabor.Infra.Data/FinoSabor.Infra.Data.csproj", "src/FinoSabor.Infra.Data/"]
RUN dotnet restore "src/FinoSabor.Services.Api/FinoSabor.Services.Api.csproj"
COPY . .
WORKDIR "/src/src/FinoSabor.Services.Api"
RUN dotnet build "FinoSabor.Services.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FinoSabor.Services.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FinoSabor.Services.Api.dll"]