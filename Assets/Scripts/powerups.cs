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
    public karäktar kr;


    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (es.waveOver == true)
        {
            powerup.SetActive(true);
        }
        else if (es.waveOver == false)
        {
            powerup.SetActive(false);

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
