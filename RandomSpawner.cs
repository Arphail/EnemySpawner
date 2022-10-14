using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnPoints;

    private float _respawnTime = 2f;

    private void Start()
    {
        StartCoroutine(WaitBeforeRespawn());
    }

    private IEnumerator WaitBeforeRespawn()
    {
        while (FindObjectOfType<Player>())
        {
            foreach (var spawnPoint in _spawnPoints)
            {
                if (spawnPoint.IsBusy == false)
                {
                    yield return new WaitForSeconds(_respawnTime);
                    spawnPoint.SpawnEnemy();
                }
            }
        }
    }
}
