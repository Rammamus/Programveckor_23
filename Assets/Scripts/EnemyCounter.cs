using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Zion
public class EnemyCounter : MonoBehaviour
{
    public GameObject Enemy;
    public List<GameObject> enemyList = new List<GameObject>();
    string spawn;
   
    string newEnemies;
    public Wave wave;
  
    
    public Enemy[] enemies;
    public ENEMYSPAWNER[] SpawnWave;
  





    // Start is called before the first frame update
    void Start()
    {
        noOfEnemies = 0;
    }

    public int noOfEnemies;
  
  


    // Update is called once per frame
    void Update()
    {
        SpawnWave = FindObjectsOfType<ENEMYSPAWNER>();
        enemies = FindObjectsOfType<Enemy>();
        //enemies.Length

    }
    public void AddPoints(int amount)
    {
        noOfEnemies += amount;

    }
}
