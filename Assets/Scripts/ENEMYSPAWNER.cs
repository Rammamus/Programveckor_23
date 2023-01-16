using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//wave namn, nummmer av enemies, vilken sort enemy, spawner.
public class Wave
{
    public string waveName;
    public int noOfEnemies;
    public GameObject[] typeOfEnemies;
    public float spawnInterval;
}

//räknar vilken wave och spawnpoints för enemies
public class ENEMYSPAWNER : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spawnPoint;

    private Wave currentWave;
    private int currentWaveNumber = 1;
    private float nextSpawnTime;

    private bool canSpawn = true;

    public TMPro.TextMeshProUGUI timer;
    public TMPro.TextMeshProUGUI currentWaveNum;

    public bool waveOver = false;
    public float waveTimer;
    public int timer2 = 30;





        private void Update()
    {
        currentWave = waves[currentWaveNumber];
        SpawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (totalEnemies.Length == 0 && !canSpawn && currentWaveNumber+1 != waves.Length)
        {
            currentWaveNumber++;
            canSpawn = true;
        }
        if (waveOver == true)
        {

            waveTimer += Time.deltaTime;
            if (waveTimer >= 1)
            {
                waveTimer = 0;
                timer2--;
            }
        }

        currentWaveNum.text = "wave: " + currentWaveNumber.ToString();
      

        timer.text = "time: " + timer2.ToString();

        if (canSpawn == true)
        {
            waveOver = false;
            timer2 = 30;

        }
    }

    void SpawnNextWave()
    {


    }





    //spawner till enemies och väljer vilka enemies


    void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
        GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];
        Transform randomPoint = spawnPoint[Random.Range(0, spawnPoint.Length)];
        Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
            currentWave.noOfEnemies--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
        }
        if (currentWave.noOfEnemies == 0)
        {
            canSpawn = false;
            waveOver = true;
        }

      
    }





}

