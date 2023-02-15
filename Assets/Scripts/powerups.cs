using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerups : MonoBehaviour
{

    public ENEMYSPAWNER es;
    public GameObject[] powerup;
    public float speedpwr = 1.25f;
    public float pwrpwr = 1.25f;
    public float healthpwr = 10f;
    public karäktar kr;
    bool x;


    // Start is called before the first frame update
    void Start()
    {
        

    }
    // när en wave är klar så kommer det upp powerups- casper.
    // Update is called once per frame
    void Update()
    {
        if (es.waveOver == true)
        {
            powerup[0].SetActive(true);
            powerup[1].SetActive(true);
            powerup[2].SetActive(true);
            x = false;
            print("aktiv");
        }
        if (es.waveOver == false)
        {
            powerup[0].SetActive(false);
            powerup[1].SetActive(false);
            powerup[2].SetActive(false);
            x = true;
            print("inaktiv");

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
