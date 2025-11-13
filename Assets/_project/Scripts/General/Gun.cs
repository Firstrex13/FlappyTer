using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] protected Bullet _bulletPrefab;
    [SerializeField] protected int _bulletsCount;
    [SerializeField] protected Transform _spawnPosition;
    [SerializeField] protected float _speed;

    protected ObjectPool<Bullet> _bulletPool;

    protected PlayerInput _playerInput;


    public void Initialize(PlayerInput input)
    {
        _playerInput = input;
    }

    protected virtual void OnShoot()
    {
        Bullet bullet = _bulletPool.GetFromPool();
        bullet.Initialize(transform.right, _spawnPosition.position, _speed);

        bullet.Collided += OnReturnToPool;
    }

    private void OnReturnToPool(Bullet bullet)
    {
        _bulletPool.ReturnObject(bullet);

        bullet.Collided -= OnReturnToPool;
    }
}
