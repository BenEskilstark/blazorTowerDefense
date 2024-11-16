namespace blazorTowerDefense.ECS.Entities;

using Coord = (int X, int Y);

public abstract class Entity()
{
    public int EntityID { get; set; }
    public virtual string Name { get; set; } = "";
    public Coord Position { get; set; }
    public string Color { get; set; } = "orange";

    public abstract int? Fuel { get; set; }


    public override string ToString()
    {
        string res = $"#{EntityID}, Name: {Name}, At: {Position}, ";
        if (Color != null) res += $"Color: {Color}\n";
        if (Fuel != null) res += $"Fuel: {Fuel}";

        return res;
    }
}