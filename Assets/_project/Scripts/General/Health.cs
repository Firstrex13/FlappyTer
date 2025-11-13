using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxValue;
    [SerializeField] private float _currentValue;

    private int _collideDamage = 1;

    public event Action Hit;
    public event Action<GameObject> Died;

    public float CurrentHealth => _currentValue;
    public int MaxValue => _maxValue;

    public void Initialize()
    {
        _currentValue = _maxValue;
    }

    public void TakeDamage(float damage)
    {
        if (_currentValue > 0)
        {
            if (damage < 0)
            {
                damage = 0;
            }

            if (damage > 0)
            {
                _currentValue -= damage;

                if (_currentValue <= 0)
                {
                    _currentValue = 0;

                    Died?.Invoke(gameObject);

                }

                Hit?.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health health))
        {
            health.TakeDamage(_collideDamage);
        }
        else if(collision.TryGetComponent<Wall>(out _))
        {
            TakeDamage(_collideDamage);
        }
    }
}

