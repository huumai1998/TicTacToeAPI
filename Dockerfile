FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TicTacToeAPI.csproj", "TicTacToeAPI/"]
RUN dotnet restore "TicTacToeAPI/TicTacToeAPI.csproj"
COPY . "TicTacToeAPI/"
WORKDIR "/src/TicTacToeAPI"
RUN dotnet build "TicTacToeAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TicTacToeAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TicTacToeAPI.dll"]
