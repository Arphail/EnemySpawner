using System.Collections;
using UnityEngine;

public class SpawnOperator : MonoBehaviour
{
    private Spawner[] _spawners;
    private bool _canSpawn;
    private float _respawnTime = 2f;
    private WaitForSeconds _waitBeforeSpawn;

    private void Start()
    {
        _spawners = GetComponentsInChildren<Spawner>();
        _waitBeforeSpawn = new WaitForSeconds(_respawnTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            _canSpawn = true;
            StartCoroutine(WaitBeforeRespawn());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            _canSpawn = false;
            StopCoroutine(WaitBeforeRespawn());
        }
    }
    
    private IEnumerator WaitBeforeRespawn()
    {
        while (_canSpawn)
        {
            foreach (var spawnPoint in _spawners)
            {
                if (spawnPoint.IsBusy == false)
                    spawnPoint.Spawn();

                yield return _waitBeforeSpawn;
            }
        }
    }
}
