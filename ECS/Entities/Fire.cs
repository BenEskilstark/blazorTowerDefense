namespace blazorTowerDefense.ECS.Entities;

public class Fire(EntityContext entityContext)
    : Entity(entityContext)
{
    public override string Name { get; set; } = "Fire";
    public override int? Fuel { get; set; } = 10;
}