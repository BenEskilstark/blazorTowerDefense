namespace blazorTowerDefense.ECS.Systems;

using blazorTowerDefense.ECS.Entities;

public class FuelSystem() : System()
{
    public override bool IsRelevant(Entity entity)
    {
        return entity.Fuel != null;
    }

    public override void Update(EntityContext entities)
    {
        entities.ForEach(entity =>
        {
            if (!IsRelevant(entity)) return;

            entity.Fuel--;
            if (entity.Fuel < 0)
            {
                entities.RemoveEntity(entity);
            }
        });
    }
}