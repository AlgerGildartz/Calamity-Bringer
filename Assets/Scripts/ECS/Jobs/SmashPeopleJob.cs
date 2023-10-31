using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[BurstCompile]
public partial struct SmashPeopleJob : IJobEntity
{
    public EntityCommandBuffer EntityCommandBuffer;
    public float3 PlayerPosition;
    
    public void Execute(PersonAspect personAspect)
    {
        float3 position = personAspect.GetAspectPosition();

        if(math.distancesq(PlayerPosition, position) < 75)
        {
            EntityCommandBuffer.DestroyEntity(personAspect.GetAspectEntity());
        }
    }
}
