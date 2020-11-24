using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooterComponent : MonoBehaviour
{
    public Transform exit;
    public ObjectPoolComponent projectileObjectPool;

    public void Shoot()
    {
        var recycledProjectile = projectileObjectPool.GetObject();
        if (recycledProjectile != null)
            ResetProjectile(recycledProjectile);
    }

    private void ResetProjectile(GameObject recycledProjectile)
    {
        recycledProjectile.transform.position = exit.position;
        recycledProjectile.transform.rotation = exit.rotation;
        recycledProjectile.SetActive(true);
    }
}
