using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//wave namn, nummmer av enemies, vilken sort enemy, spawner.

public class Wave
{
    //ocean
    public string waveName;
    public int noOfEnemies= 0;
    public GameObject[] typeOfEnemies;
    public float spawnInterval;

}

//räknar vilken wave och spawnpoints för enemies
public class ENEMYSPAWNER : MonoBehaviour
{
    // Ocean
    public karäktar player;
    public Wave[] waves;
    public Transform[] spawnPoint;
    public CoinCounter cc;

    private Wave currentWave;
    private int currentWaveNumber = 1;
    private float nextSpawnTime;

    private bool canSpawn = true;

    public TMPro.TextMeshProUGUI timer;
    public TMPro.TextMeshProUGUI currentWaveNum;

    public bool waveOver = false;
    public float waveTimer;
    public int timer2 = 15;

    public List<GameObject> enemies = new List<GameObject>();

    //Ocean
        void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public GameObject betweenWaveTimer;

    

        private void Update()
    {
        //enemy counter (list)
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] == null)
            {
                enemies.RemoveAt(i);
            }
        }
        //ocean wave counter
        currentWave = waves[currentWaveNumber];
        SpawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (totalEnemies.Length == 0)
        {
            
            if (timer2 == 0)
            {
                canSpawn = true;
                waveOver = false;
                currentWaveNumber++;
            }
            

        }

        //ocean enemy counter
        if (enemies.Count == 0)
        {
            waveOver = true;
            print("0mobs");
        }

        
         // William och Ocean (Ocean gjorde timer, William gjorde coins)
        if (waveOver == true)
        {
            betweenWaveTimer.SetActive(true);
            waveTimer += Time.deltaTime;
            if (waveTimer >= 1)
            {
                waveTimer = 0;
                timer2--;
                print("countdown");
            }

            player.coins += 5; // player.coins += 5;
            cc.IncreaseCoins(5);
           
        }
        else if (waveOver == false)
        {
            betweenWaveTimer.SetActive(false);
        }

        currentWaveNum.text = "wave: " + currentWaveNumber.ToString();
      

        timer.text = "time: " + timer2.ToString();
        //ocean gör så att timermn resets
        if (canSpawn == true)
        {
            waveOver = false;
            timer2 = 15;

        }
    }

 





    //spawner till enemies och väljer vilka enemies

    //SpawnWave - Ocean
    void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
        GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];
        Transform randomPoint = spawnPoint[Random.Range(0, spawnPoint.Length)];
        enemies.Add( Instantiate(randomEnemy, randomPoint.position, Quaternion.identity));
            enemies[enemies.Count - 1].GetComponent<Enemy>().spawner = this;
            currentWave.noOfEnemies--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
        }
        if (currentWave.noOfEnemies == 0)
        {
            canSpawn = false;
            
        }

      
    }





}

