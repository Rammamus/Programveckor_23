using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBinSpawner : MonoBehaviour
{
    public GameObject ProjectilePreFab;
    public Transform LaunchOffset;

    float enemySpawnTime;
    public int enemyCount = 0;
    [SerializeField] public int maxEnemy;
    bool canSpawn = true;

    private void start()
    {
    }
    private void Update()
    {
        enemySpawnTime += Time.deltaTime;

        if (enemySpawnTime > 5 && canSpawn == true)
        {
            Instantiate(ProjectilePreFab, LaunchOffset.position, transform.rotation);
            enemySpawnTime = 0;
            enemyCount++;
        }
    }
}
