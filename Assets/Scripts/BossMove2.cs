using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossMove2 : MonoBehaviour
{
    private bool isDashing;
    private bool canDash;
    private bool isPreparingForDash;
    public Transform player;
    public karäktar kr;
    public BossMove bm;
    // Start is called before the first frame update
    void Start()
    {
        bm = GetComponent<BossMove>();
        canDash = true;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist <= bm.bossrange && canDash)
        {
            StartCoroutine(DashMovementHandler());
            if (isDashing && !isPreparingForDash)
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * kr.playSpeed * 20); 
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * kr.playSpeed * 0.25f);
        }
    }
    IEnumerator DashMovementHandler()
    {
        canDash = false;
        isPreparingForDash = true;

        yield return new WaitForSeconds(0.2f);
        isDashing = true;
        isPreparingForDash = false;

        yield return new WaitForSeconds(1f);
        canDash = false;
        isDashing = false;

        yield return new WaitForSeconds(4f);
        canDash = true;
        print("did he?");
    }
}

