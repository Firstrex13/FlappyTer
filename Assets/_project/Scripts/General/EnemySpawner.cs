using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _count;
    [SerializeField] private Enemy _prefab;
    [SerializeField] private Transform _spawnPosition;

    private ObjectPool<Enemy> _pool;

    private float _spawnDelay = 1.5f;

    private void Start()
    {
        _pool = new ObjectPool<Enemy>(_prefab, _count);

        StartCoroutine(nameof(Create));
    }

    private IEnumerator Create()
    {
        WaitForSeconds delay = new WaitForSeconds(_spawnDelay);

        while (enabled)
        {
            Enemy enemy = _pool.GetFromPool();
            enemy.Initialize(_spawnPosition.position);
            Health health = enemy.GetComponent<Health>();
            health.Initialize();
            yield return delay;
        }
    }
}
