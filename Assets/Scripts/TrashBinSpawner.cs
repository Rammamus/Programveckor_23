using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gör så att trashbin gubben kan spawna små gubbar - Adrian
public class TrashBinSpawner : MonoBehaviour
{
    public GameObject ProjectilePreFab;
    public Transform LaunchOffset;
    public SpriteRenderer spr;

    float enemySpawnTime;
    public int enemyCount = 0;
    [SerializeField] public int maxEnemy;
    bool canSpawn = true;
    public Animator amM;
    [SerializeField]
    bool Trashdie =true;
    bool isSpawningM = true;
    bool time;
    float f;
    public AudioSource spawnFX;
    private void Start()
    {
      //  spawnFX = GetComponent<AudioSource>();
        amM = GetComponent<Animator>();
    }
    private void Update()
    {
        // animation for spawning monster-Zion
        if (canSpawn == true)
        {

            amM.SetBool("isSpawningM", true);
            if (amM != null)
            {
                isSpawningM = false;
            }
        
        }

        // animation for trashbin monster dies- Zion
        if ( Trashdie == true)
        {
            amM.SetBool("TrashDie", true);
        }


        enemySpawnTime += Time.deltaTime;

        if (enemySpawnTime > 4.2f && canSpawn == true)
        {
            if (spawnFX.isPlaying == false)
            {
                spawnFX.Play(); //denna är konstig
            }
            print(gameObject.name + "Skapar saker");
            Instantiate(ProjectilePreFab, LaunchOffset.position, transform.rotation);
            enemySpawnTime = 0;
            enemyCount++;
        }

       

    }
}
