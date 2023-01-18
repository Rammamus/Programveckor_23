using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossMove2 : MonoBehaviour
{
    private bool isDashing;
    private bool canDash;
    private bool isPreparingForDash;
    public Enemy enemy;
    public karäktar kr;
    public BossMove bm;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(enemy.transform.position, transform.position);
        if (dist <= bm.bossrange && canDash)
        {
            StartCoroutine(DashMovementHandler());
            if (isDashing && !isPreparingForDash)
                transform.position = Vector2.MoveTowards(transform.position, enemy.transform.position, Time.deltaTime * kr.playSpeed * 10); 
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, enemy.transform.position, Time.deltaTime * kr.playSpeed * 2);
        }
    }
    IEnumerator DashMovementHandler()
    {
        canDash = true;
        isPreparingForDash = true;

        yield return new WaitForSeconds(0.5f);
        isDashing = true;
        isPreparingForDash = false;

        yield return new WaitForSeconds(0.2f);
        canDash = false;
        isDashing = false;

        yield return new WaitForSeconds(4f);
        canDash = true;
    }
}

