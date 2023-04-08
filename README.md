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

Clone this Git repositories to your local machine.

```cmd
git clone <Tic-Tac-Toe_url>
```

To Run Dockerfile. Open Terminal

```C#
docker build -t tictactoeapi .
```

Run Docker container using docker image just build.
Use this command

```C#
docker run -p 8080:80 tictactoeapi
```

This command runs a Docker container using the "tictactoeapi" image, 
and maps port 8080 on the host machine to port 80 in the container.

Access the API using a web browser or a tool such as Postman. The API should now be 
available at http://localhost:8080/api.


To run the Docker containers using Docker Compose, navigate to the root directory of your project and run the following command:

```C#
docker-compose up
```
This command starts the containers and displays their logs in the terminal window. You can stop the containers by pressing Ctrl+C.

# Troubleshooting

Check your lastest version of dotnet to make sure enviroment variables are set correctly.

# Endpoints
The Tic-Tac-Toe API provides the following endpoints:

# Start a game
Adds an endpoint for starting a game. This endpoint should return a game Id and Ids for the two players.
 
* URL `/api/games`
* HTTP method: `POST`
* Request body:
```json
{
  "player1Id": "string",
  "player2Id": "string"
}
```

* Response body:
```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "player1Id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "player1": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "name": "string",
    "symbol": 0,
    "moves": [
      {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "gameId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "game": "string",
        "playerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "player": "string",
        "row": 0,
        "column": 0,
        "timestamp": "2023-04-08T01:27:29.916Z"
      }
    ]
  },
  "player2Id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "player2": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "name": "string",
    "symbol": 0,
    "moves": [
      {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "gameId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "game": "string",
        "playerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "player": "string",
        "row": 0,
        "column": 0,
        "timestamp": "2023-04-08T01:27:29.916Z"
      }
    ]
  },
  "moves": [
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "gameId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "game": "string",
      "playerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "player": "string",
      "row": 0,
      "column": 0,
      "timestamp": "2023-04-08T01:27:29.916Z"
    }
  ],
  "isGameOver": true
}
```

# Register a player move
Adds an endpoint for registering a player move. This endpoint should take the player Id and return a success response or appropriate errors. It should also notify the caller if the current move wins the game.

* URL: `api\games\{id}\moves`
* HTTP method: `POST`
* Request body:
```json
{
  "playerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "row": 2,
  "column": 2
}
```

* Response body:
```json
{
  "success": boolean,
  "winnerId": "string"
}
```
# Retrieve a list of currently running games
Add endpoint for retrieve a list of currently running games.
* URL `api/games/{id}`
* HTTP method: `GET`
* response body:
```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "player1Id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "player1": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "name": "string",
    "symbol": 0,
    "moves": [
      {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "gameId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "game": "string",
        "playerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "player": "string",
        "row": 0,
        "column": 0,
        "timestamp": "2023-04-08T01:34:28.433Z"
      }
    ]
  },
  "player2Id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "player2": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "name": "string",
    "symbol": 0,
    "moves": [
      {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "gameId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "game": "string",
        "playerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "player": "string",
        "row": 0,
        "column": 0,
        "timestamp": "2023-04-08T01:34:28.433Z"
      }
    ]
  },
  "moves": [
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "gameId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "game": "string",
      "playerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "player": "string",
      "row": 0,
      "column": 0,
      "timestamp": "2023-04-08T01:34:28.433Z"
    }
  ],
  "isGameOver": false
}
  
```

# Appropriate OAuth 2/OIDC

The Authorization Code flow is a secure OAuth 2.0 flow that is recommended
for server-side web applications like the Tic-Tac-Toe API.
This flow involves redirecting the user to an authorization server's
login page to authenticate themselves and grant permission for the client application to
access their data. Once the user has granted permission, the API exchanges the authorization
code for an access token and a refresh token. This flow is more secure than other
OAuth 2.0 flows because the authorization code is only exchanged on the server-side,
where it is less vulnerable to interception or tampering.
