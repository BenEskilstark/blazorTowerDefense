namespace blazorTowerDefense.Models;

using blazorTowerDefense.ECS.Entities;
using blazorTowerDefense.ECS.Systems;

public class Game(int gameID, Player host)
{
    public int GameID { get; } = gameID;
    public bool IsStarted { get; set; } = false;
    public event Action? Notify;

    public List<Player> Players { get; set; } = [host];
    public int MaxPlayers { get; } = 2;

    public bool IsHost(int playerID)
    {
        return Players.FirstOrDefault(p => true)?.PlayerID == playerID;
    }

    private EntityContext Entities { get; set; } = new();
    private List<System> Systems { get; set; } = [
        new BurnSystem(),
    ];
    public int Tick { get; private set; } = 0;
    private Timer? UpdateInterval { get; set; }

    public void Start()
    {
        IsStarted = true;
        Entities = new();

        Entities.AddEntity(new Fire(Entities) { Fuel = 20 });

        Tick = 0;
        UpdateInterval = new((object? s) => Update(), null, 0, 500);
        Notify?.Invoke();
    }

    public void Update()
    {
        Tick++;
        Console.WriteLine("Tick");
        Entities.ForEach(Console.WriteLine);
        Systems.ForEach(s => s.Update(Entities));
        Notify?.Invoke();
    }

}