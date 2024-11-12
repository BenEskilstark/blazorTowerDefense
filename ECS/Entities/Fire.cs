namespace blazorTowerDefense.ECS.Entities;

public class Fire(EntityContext entityContext)
    : Entity(entityContext)
{
    public new string Name { get; set; } = "Fire";
    public new int Fuel { get; set; } = 10;
}