namespace blazorTowerDefense.Models;

public class Game(int gameID, Player host)
{
    public int GameID { get; } = gameID;
    public bool IsStarted { get; set; } = false;

    public List<Player> Players { get; set; } = [host];
    public int MaxPlayers { get; } = 2;

    public bool IsHost(int playerID)
    {
        return Players.FirstOrDefault(p => true)?.PlayerID == playerID;
    }




    public void Start()
    {
        IsStarted = true;


    }

}