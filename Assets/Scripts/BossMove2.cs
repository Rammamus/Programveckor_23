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
    bool tryingToDash;
    private float dashspeed = 1.6f;
    // Start is called before the first frame update
    void Start()
    {
        bm = GetComponent<BossMove>();
        canDash = true;
    }

    // Update is called once per frame

    //dash för bossen -William
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist <= bm.bossrange && canDash)
        {
            print("Start Dash");
            if (tryingToDash == false)
            {
                StartCoroutine(DashMovementHandler());
            }
            
            if (isDashing && !isPreparingForDash)
            {
                print("Dash");
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * dashspeed * 5); // sänk fart samt gör så att shop och power inte ändrar, fixa playspeed.
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * dashspeed * 0.25f);
        }
    }


    // cooldowns och tid för dashen.
    IEnumerator DashMovementHandler()
    {
        tryingToDash = true;
        canDash = true;
        isPreparingForDash = true;

        yield return new WaitForSeconds(0.2f);
        isDashing = true;
        isPreparingForDash = false;
        print("trying");

        yield return new WaitForSeconds(1f);
        canDash = false;
        isDashing = false;

        yield return new WaitForSeconds(4f);
        canDash = true;
        tryingToDash = false;
        print("did he?");
    }
}

