FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["OnlineEnrollmentMVC/OnlineEnrollmentMVC.csproj", "OnlineEnrollmentMVC/"]
RUN dotnet restore "OnlineEnrollmentMVC/OnlineEnrollmentMVC.csproj"
COPY . .
WORKDIR "/src/OnlineEnrollmentMVC"
RUN dotnet build "OnlineEnrollmentMVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OnlineEnrollmentMVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnlineEnrollmentMVC.dll"]