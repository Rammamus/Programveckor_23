using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchOffsetScriprt : MonoBehaviour
{
    public Transform tm;
    public kar�ktar player;
    public SpriteRenderer spr;
     string v�nster;
     string h�ger;
    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<Transform>();
        spr = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Aims towards where the attack is aimed and locks the rotation of the attack during the attack duration - Adrian
        if (player.GetComponent<kar�ktar>().isAttacking == false)
        {
            Vector3 targetDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = (Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg);
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        

        /*
        if (Input.GetKey(v�nster))
        {
            if (true)
            {
               spr.flipX = true;
            }
            if (spr != null)
            {
                spr.flipX = true;
            }
        }
        if (Input.GetKey(h�ger))
        {
            if (true)
            {
               spr.flipX = false;
            }

        }
        */
    }
}
