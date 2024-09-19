FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/ProZaghdadV1.Web.Host/ProZaghdadV1.Web.Host.csproj", "src/ProZaghdadV1.Web.Host/"]
COPY ["src/ProZaghdadV1.Web.Core/ProZaghdadV1.Web.Core.csproj", "src/ProZaghdadV1.Web.Core/"]
COPY ["src/ProZaghdadV1.Application/ProZaghdadV1.Application.csproj", "src/ProZaghdadV1.Application/"]
COPY ["src/ProZaghdadV1.Core/ProZaghdadV1.Core.csproj", "src/ProZaghdadV1.Core/"]
COPY ["src/ProZaghdadV1.EntityFrameworkCore/ProZaghdadV1.EntityFrameworkCore.csproj", "src/ProZaghdadV1.EntityFrameworkCore/"]
WORKDIR "/src/src/ProZaghdadV1.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/ProZaghdadV1.Web.Host", "src/ProZaghdadV1.Web.Host"]
COPY ["src/ProZaghdadV1.Web.Core", "src/ProZaghdadV1.Web.Core"]
COPY ["src/ProZaghdadV1.Application", "src/ProZaghdadV1.Application"]
COPY ["src/ProZaghdadV1.Core", "src/ProZaghdadV1.Core"]
COPY ["src/ProZaghdadV1.EntityFrameworkCore", "src/ProZaghdadV1.EntityFrameworkCore"]
WORKDIR "/src/src/ProZaghdadV1.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "ProZaghdadV1.Web.Host.dll"]
