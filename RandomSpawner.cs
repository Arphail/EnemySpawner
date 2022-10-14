using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnPoints;
    
    private bool _canSpawn;
    private float _respawnTime = 2f;
    private WaitForSeconds _waitBeforeSpawn;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
            _canSpawn = false;
    }

    private void Start()
    {
        _canSpawn = true;
        _waitBeforeSpawn = new WaitForSeconds(_respawnTime);
        StartCoroutine(WaitBeforeRespawn());
    }

    private IEnumerator WaitBeforeRespawn()
    {
        while (_canSpawn)
        {
            foreach (var spawnPoint in _spawnPoints)
            {
                if (spawnPoint.IsBusy == false)
                    spawnPoint.SpawnEnemy();

                yield return _waitBeforeSpawn;
            }
        }
    }
}
