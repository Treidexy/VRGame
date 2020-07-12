using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyManager : MonoBehaviour
{
    public GameObject prefab;

    public void SpawnEnemy(Transform spawnPos)
    {
        GameObject enemyToSpawn = Instantiate(prefab);
        enemyToSpawn.transform.position = spawnPos.position;
        enemyToSpawn.transform.rotation = spawnPos.rotation;
    }
}