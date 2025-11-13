using System.Collections;
using UnityEngine;

public class EnemyGun : Gun
{
    private float _ShootTime = 2f;

    private void Start()
    {
        _bulletPool = new ObjectPool<Bullet>(_bulletPrefab, _bulletsCount);      
    }

    public void Attack()
    {
        StartCoroutine(nameof(Shoot));
    }
    private IEnumerator Shoot()
    {
        WaitForSeconds delay = new WaitForSeconds(_ShootTime);

        while (enabled)
        {
            yield return delay;
            OnShoot();
            yield return delay;
        }
    }
}
