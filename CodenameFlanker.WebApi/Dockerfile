#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 444
ENV ASPNETCORE_URLS=https://+:444

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["CodenameFlanker.WebApi/CodenameFlanker.WebApi.csproj", "CodenameFlanker.WebApi/"]
COPY ["CodenameFlanker.Contracts/CodenameFlanker.Contracts.csproj", "CodenameFlanker.Contracts/"]
COPY ["CodenameFlanker.Data/CodenameFlanker.Data.csproj", "CodenameFlanker.Data/"]
COPY ["CodenameFlanker.Services/CodenameFlanker.Services.csproj", "CodenameFlanker.Services/"]
RUN dotnet restore "CodenameFlanker.WebApi/CodenameFlanker.WebApi.csproj"
COPY . .
WORKDIR "/src/CodenameFlanker.WebApi"
RUN dotnet build "CodenameFlanker.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CodenameFlanker.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CodenameFlanker.WebApi.dll"]