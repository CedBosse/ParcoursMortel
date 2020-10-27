using UnityEngine;

[RequireComponent(typeof(MoveForwardComponent))]
[RequireComponent(typeof(DisableOverTimeComponent))]

public class ProjectileComponent : MonoBehaviour, IPoolable
{
    public ObjectPoolComponent AssociatedPool { get; set; }
    private void Awake()
    {
        var trailRenderer = GetComponentInChildren<TrailRenderer>();
        GetComponent<DisableOverTimeComponent>().onDisable = () =>
        {
            AssociatedPool.PutObject(gameObject);
            if (trailRenderer != null)
                trailRenderer.Clear();
        };
    }
}
