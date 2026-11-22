FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["wt_lab8_8razor_postgresql_lyashuk.csproj", "./"]
RUN dotnet restore "./wt_lab8_8razor_postgresql_lyashuk.csproj"

COPY . .
RUN dotnet publish "./wt_lab8_8razor_postgresql_lyashuk.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
EXPOSE 10000

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "wt_lab8_8razor_postgresql_lyashuk.dll"]