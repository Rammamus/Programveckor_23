using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerups : MonoBehaviour
{

    public ENEMYSPAWNER es;
    public GameObject powerup;
    public float speedpwr = 1.25f;
    public float pwrpwr = 1.25f;
    public float healthpwr = 10f;
    public kar�ktar kr;
    bool x;


    // Start is called before the first frame update
    void Start()
    {
        

    }
    // n�r en wave �r klar s� kommer det upp powerups- casper.
    // Update is called once per frame
    void Update()
    {
        if (es.waveOver == true && x == true)
        {
            powerup.SetActive(true);
            x = false;
        }
        if (es.waveOver == false)
        {
            powerup.SetActive(false);
            x = true;

        }

        
    }

    

    public void speed()
    {
        kr.playSpeed *= speedpwr;
    }

    public void power ()
    {
        kr.playDMG *= pwrpwr;
    }

    public void health()
    {
        kr.playHP *= healthpwr;
    }
    
    
}
