# TicTacToeAPI

This is a .NET 6.0 Web API that provides endpoints for managing games of Tic-Tac-Toe. It uses Entity Framework and a database of your choice (an in-memory database is fine) to manage game data.

# Prerequisites

This project using .NET 6.0 Web API. To make sure you have them available on your machine, try running the following command.

```C#
$ dotnet --version
```

# Configuration

Copy your SQL Server Management to (/appsettings.json) file.

# Getting Start

To Run Dockerfile. Open Terminal

```C#
docker build -t tictactoeapi .
```

Run Docker container using docker image just build.
Use this command

```C#
docker run -p 8080:80 tictactoeapi
```

# Troubleshooting

Check your lastest version of dotnet to make sure enviroment variables are set correctly.

# Appropriate OAuth 2/OIDC

The Authorization Code flow is a secure OAuth 2.0 flow that is recommended
for server-side web applications like the Tic-Tac-Toe API.
This flow involves redirecting the user to an authorization server's
login page to authenticate themselves and grant permission for the client application to
access their data. Once the user has granted permission, the API exchanges the authorization
code for an access token and a refresh token. This flow is more secure than other
OAuth 2.0 flows because the authorization code is only exchanged on the server-side,
where it is less vulnerable to interception or tampering.
