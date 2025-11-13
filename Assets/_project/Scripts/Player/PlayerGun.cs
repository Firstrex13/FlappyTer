
public class PlayerGun : Gun
{
    private void Start()
    {
        _bulletPool = new ObjectPool<Bullet>(_bulletPrefab, _bulletsCount);

        _playerInput.ShootButtonPressed += OnShoot;
    }

    private void OnDestroy()
    {
        _playerInput.ShootButtonPressed -= OnShoot;
    }
}
