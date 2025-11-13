using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;

    private Vector3 _spawnPosition;

    private int _value = 5;

    private void Start()
    {
        transform.position = _spawnPosition;
    }

    public void Initialize(Vector3 position)
    {
        position.x = position.x + _offset.x;
        position.y = _spawnPosition.y + Random.Range(-_value, _value);
        _spawnPosition = position;
    }
}
