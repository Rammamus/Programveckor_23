using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMuve : MonoBehaviour
{
    public float chaseDistance;
    public bool isChasing;
    public float moveSpeed;
    public karäktar player;
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
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }
            if (transform.position.x < player.transform.position.x) 
            {
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
