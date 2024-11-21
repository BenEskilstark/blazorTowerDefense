namespace blazorTowerDefense.ECS.Entities;

public class Fire() : Entity()
{
    public override string Name { get; set; } = "Fire";
    public override int? Fuel { get; set; } = 10;
    public override int? Intensity { get; set; } = 1;
}