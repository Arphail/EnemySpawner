using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _tempLate;

    private Enemy _spawnedEnemy;

    public bool IsBusy { get; private set; }

    private void Update()
    {
        if (_spawnedEnemy == null)
            IsBusy = false;
    }

    public void SpawnEnemy()
    {
        _spawnedEnemy = Instantiate(_tempLate, transform.position, Quaternion.identity);
        IsBusy = true;
    }
}
