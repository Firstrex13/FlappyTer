using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private ShipTracker _shipTracker;
    [SerializeField] private PlayerSpawner _playerSpawner;

    private void Awake()
    {
        _playerSpawner.Initialize(_playerInput, _shipTracker);
    }
}
