using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Ship _playerPrefab;
    [SerializeField] private Transform _spawnPosition;

    private PlayerInput _playerInput;
    private ShipTracker _shipTracker;

    private void Awake()
    {
        var player = Instantiate(_playerPrefab, _spawnPosition.position, transform.rotation);

        if(player.TryGetComponent<ShipMover>(out ShipMover shipMover))
        {
            shipMover.Initialize(_playerInput);
        }

        _shipTracker.Initialize(player);
    }

    public void Initialize(PlayerInput input, ShipTracker shipTracker)
    {
        _playerInput = input;
        _shipTracker = shipTracker;
    }
}
