using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchOffsetScriprt : MonoBehaviour
{
    public GameObject scale;
    public karäktar player;
    public SpriteRenderer spr;
    public Transform tm;
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        
        spr = GetComponent<SpriteRenderer>();
        player = GetComponent<karäktar>();
        tm = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Aims towards where the attack is aimed and locks the rotation of the attack during the attack duration - Adrian
        if (player.GetComponent<karäktar>().attack == false)
        {
 
        }
        Vector3 targetDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = (Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Input.GetKeyDown(KeyCode.A))
        {
            

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            
        }
       
    }
}
