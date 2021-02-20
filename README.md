# planning-poker
Planning Poker system with .Net Core 3.1 and Angular

# Install
## Client
`cd /planning-poker-client`
`npm install`
`npm start`

## Server
#### Doker
`cd /docker`
`docker-compose up -d`
#### .Net Core
`cd /PlanningPokerServer`
`dotnet restore`
`dotnet build`
`dotnet ef database update`
`dotnet run`
