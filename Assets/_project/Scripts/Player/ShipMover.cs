using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class ShipMover : MonoBehaviour
{
    [SerializeField] private float _flyUpStrength;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody2D;
    private Vector3 _startPosition;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }    

    private void Start()
    {
        _playerInput.FlyUpButtonPressed += OnFlyUp;

        _startPosition = transform.position;
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    private void OnDestroy()
    {
        _playerInput.FlyUpButtonPressed -= OnFlyUp;
    }

    public void Initialize(PlayerInput input)
    {
        _playerInput = input;
    }

    private void OnFlyUp()
    {
        _rigidbody2D.linearVelocity = new Vector2(_speed, _flyUpStrength);
        transform.rotation = _maxRotation;
    }
}
