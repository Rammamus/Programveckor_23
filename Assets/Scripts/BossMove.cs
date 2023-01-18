using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove: MonoBehaviour
{
    public float chaseDistance;
    public bool isChasing;
    public float moveSpeed;
    public karäktar player;

    private float activeMovespeed;
    private float dachspeed;
    public float bossrange = 10; // ändra 10an senare
    public string target;

    private float dashlength = 5f, dashCoolDown = 1f;

    private float dashCaunter;
    private float dashCoolCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindObjectOfType<karäktar>();

        if (isChasing)
        {
            if(transform.position.x > player.transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }
               
            if (transform.position.x < player.transform.position.x) 
            {
                transform.localScale = new Vector3(-1, 1, 1);
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
        }

        else
        {
            if(Vector2.Distance(transform.position, player.transform.position) < chaseDistance)
            {
                isChasing = true;
            }

            /*
            if (patrolDestination == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed);
                if(Vector2.Distance(transform.position, patrolPoints[0].posetion) < .2f)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    patrolDestination = 1;
                }
            }*/
        } 
    } 
}
