namespace blazorTowerDefense.ECS.Systems;

using blazorTowerDefense.ECS.Entities;

using Coord = (int X, int Y);

public class FireSystem() : System()
{
    public override bool IsRelevant(Entity entity)
    {
        return entity.Name == "Fire";
    }

    public override void Update(EntityContext entities)
    {
        entities.ForEach(entity =>
        {
            if (!IsRelevant(entity)) return;

            entity.Intensity = Math.Min((int)entity.Intensity! + 1, 10);

            if (entity.Intensity == 10)
            {
                List<Coord> nPos = entities.World.GetNeighbors(entity.Position);
                foreach (Coord n in nPos)
                {
                    if (entities.World.At(n)?.Count == 0 && entities.Rand.Next(100) < 6)
                    {
                        entities.AddEntity(new Fire() { Fuel = 20, Position = n });
                    }
                }
            }
        });
    }
}