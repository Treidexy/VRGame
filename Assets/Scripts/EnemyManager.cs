using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject prefab;

    public void SpawnEnemy(Transform spawnTransform)
    {
        Instantiate(prefab, spawnTransform);
    }
}
