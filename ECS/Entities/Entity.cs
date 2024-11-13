namespace blazorTowerDefense.ECS.Entities;

using Coord = (int X, int Y);

public abstract class Entity(EntityContext entityContext)
{
    public int EntityID { get; set; } = entityContext.NextEntityID;
    public virtual string Name { get; set; } = "";
    public Coord Position { get; set; }

    public abstract int? Fuel { get; set; }


    public override string ToString()
    {
        string res =
@$"ID: {EntityID}
Name: {Name}
Position: {Position}
";
        if (Fuel != null) res += $"Fuel: {Fuel}";

        return res;
    }
}