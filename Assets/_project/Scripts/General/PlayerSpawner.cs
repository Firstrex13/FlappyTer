using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Ship _playerPrefab;
    [SerializeField] private Transform _spawnPosition;

    private PlayerInput _playerInput;
    private ShipTracker _shipTracker;

    private void Start()
    {
        CreatePlayer();
    }

    public void Initialize(PlayerInput input, ShipTracker shipTracker)
    {
        _playerInput = input;
        _shipTracker = shipTracker;
    }

    private void CreatePlayer()
    {
        var player = Instantiate(_playerPrefab, _spawnPosition.position, transform.rotation);

        if (player.TryGetComponent<ShipMover>(out ShipMover shipMover))
        {
            shipMover.Initialize(_playerInput);
        }

        if (player.TryGetComponent<Health>(out Health health))
        {
            health.Initialize();
        }

        if (player.TryGetComponent<Gun>(out Gun gun))
        {
            gun.Initialize(_playerInput);
        }

        _shipTracker.Initialize(player);
    }
}
