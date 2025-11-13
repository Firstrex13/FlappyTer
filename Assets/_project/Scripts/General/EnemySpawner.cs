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

            if (enemy.TryGetComponent<Health>(out Health health))
            {
                health.Initialize();
                health.Died += ReturnToPool;
                yield return delay;
            }
        }
    }

    private void ReturnToPool(GameObject enemyHealth)
    {
        if (enemyHealth.TryGetComponent<Health>(out Health health))
        {
            if(enemyHealth.TryGetComponent<Enemy>(out Enemy enemy))
            _pool.ReturnObject(enemy);
            health.Died -= ReturnToPool;
        }
    }
}
