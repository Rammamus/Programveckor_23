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
    public Animator amM;
    bool isSpawningM = true;
    private void start()
    {
        amM = GetComponent<Animator>();
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
        
        // animation for spawning monster-Zion
        if (canSpawn == true)
        {
            amM.SetBool("isSpawningM", true);
            if (amM != null)
            {
                isSpawningM = false;
            }
        }
    }
}
