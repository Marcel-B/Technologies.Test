
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Technology.Pages.csproj", "Technology.Pages/"]
RUN dotnet restore "Technology.Pages/Technology.Pages.csproj"
COPY . ./Technology.Pages
WORKDIR "/src/Technology.Pages"
RUN dotnet build "Technology.Pages.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Technology.Pages.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Technology.Pages.dll"]
