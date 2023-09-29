FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["BookSell.Web/*.csproj", "BookSell.Web/"]
COPY ["Framework/*.csproj", "Framework/"]
COPY ["Membership/*.csproj", "Membership/"]
COPY ["DataAccessLayer/*.csproj", "DataAccessLayer/"]
RUN dotnet restore "BookSell.Web/BookSell.Web.csproj"
COPY . .
WORKDIR "/src/BookSell.Web"
RUN dotnet build "BookSell.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BookSell.Web.csproj" -c Release -o /app

FROM build AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BookSell.Web.dll"]