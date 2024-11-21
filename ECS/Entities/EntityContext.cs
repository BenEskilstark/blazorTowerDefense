namespace blazorTowerDefense.ECS.Entities;

using blazorTowerDefense.DataStructures;

using Coord = (int X, int Y);

public class EntityContext()
{
    private int _nextEntityID = 0;
    public int NextEntityID
    {
        get { return _nextEntityID++; }
    }

    public SparseGrid<List<Entity>> World { get; set; } = new([]);
    public Dictionary<int, Entity> Entities { get; set; } = [];

    private List<Entity> ToAdd { get; set; } = [];
    private List<Entity> ToRemove { get; set; } = [];

    public Random Rand { get; set; } = new();


    public void ForEach(Action<Entity> f)
    {
        foreach (var entity in Entities.Values)
        {
            f(entity);
        }
        OnAfterUpdate();
    }


    public List<Entity> GetNeighbors(Entity entity)
    {
        List<Coord> coords = World.GetNeighbors(entity.Position);
        List<Entity> neighbors = [];
        coords.ForEach(c => neighbors.AddRange(World.At(c) ?? []));
        return neighbors;
    }

    public void OnAfterUpdate()
    {
        foreach (var entity in ToAdd)
        {
            entity.EntityID = NextEntityID;
            Entities.Add(entity.EntityID, entity);
            World.Set(entity.Position, [.. World.At(entity.Position), entity]);
        }
        foreach (var entity in ToRemove)
        {
            Entities.Remove(entity.EntityID);
            World.Set(
                entity.Position,
                [.. World.At(entity.Position)!.Where(e => e.EntityID != entity.EntityID)]
            );
        }
        ToAdd = [];
        ToRemove = [];
    }



    public void AddEntity(Entity entity)
    {
        ToAdd.Add(entity);
    }
    public void RemoveEntity(Entity entity)
    {
        ToRemove.Add(entity);
    }

}