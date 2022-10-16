using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyTemplate;

    private Enemy _spawnedEnemy;

    public bool IsBusy { get; private set; }

    public void Update()
    {
        if(_spawnedEnemy == null)
            IsBusy = false;
    }

    public void Spawn()
    {
        if(IsBusy == false)
        {
            _spawnedEnemy = Instantiate(_enemyTemplate, transform.position, Quaternion.identity);
            IsBusy = true;
        }
    }
}
