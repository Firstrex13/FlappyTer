using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private EnemyGun _gun;

    private Vector3 _spawnPosition;

    private int _value = 5;

    private void OnEnable()
    {
        Attack();
    }

    public void Initialize(Vector3 position)
    {
        position.x = position.x + _offset.x;
        position.y = _spawnPosition.y + Random.Range(-_value, _value);
        _spawnPosition = position;
        transform.position = _spawnPosition;
    }

    private void Attack()
    {
        _gun.Attack();
    }
}
