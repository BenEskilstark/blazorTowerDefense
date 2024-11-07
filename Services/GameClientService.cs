namespace blazorTowerDefense.Services;

using System;
using blazorTowerDefense.Models;
using blazorTowerDefense.Singletons;


public class GameClientService : IDisposable
{
    public GameServerSingleton GameServer { get; }
    public Player ClientPlayer { get; }

    public Game? JoinedGame { get; set; }

    public GameClientService(GameServerSingleton gameServer)
    {
        GameServer = gameServer;
        ClientPlayer = gameServer.JoinServer();
        GameServer.NotifyGameOver += (int gameID) =>
        {
            if (JoinedGame?.GameID == gameID)
            {
                JoinedGame = null;
            }
        };
    }

    public void Dispose()
    {
        if (JoinedGame != null)
        {
            GameServer.LeaveGame(ClientPlayer, JoinedGame.GameID);
        }
        GameServer.LeaveServer(ClientPlayer);
        JoinedGame = null;
    }

}