namespace blazorTowerDefense.ECS.Systems;

using blazorTowerDefense.ECS.Entities;

public abstract class System
{
    public abstract bool IsRelevant(Entity entity);
    public abstract void Update(EntityContext entities);
}