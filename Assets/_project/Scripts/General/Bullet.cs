using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _damage;

    private float _speed;
    private Vector3 _direction;
    private Vector3 _startPosition;

    public event Action<Bullet> Collided;

    public void Initialize(Vector3 direction, Vector3 startPosition, float speed)
    {
        _direction = direction;
        _startPosition = startPosition;
        _speed = speed;
        transform.position = _startPosition;
    }

    
    //private void Start()
    //{
    //    transform.position = _startPosition;
    //}

    private void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health health))
        {
            health.TakeDamage(_damage);
        }

        Collided?.Invoke(this);
    }
}
