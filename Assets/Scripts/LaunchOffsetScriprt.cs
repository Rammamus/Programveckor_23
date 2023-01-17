using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchOffsetScriprt : MonoBehaviour
{
    public karäktar player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Aims towards where the attack is aimed and locks the rotation of the attack during the attack duration - Adrian
        if (player.GetComponent<karäktar>().isAttacking == false)
        {
            Vector3 targetDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = (Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg);
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
