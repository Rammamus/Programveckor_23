using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canWalkingAnim : MonoBehaviour
{
    public Animator canWalking;
    bool isWalking;
    // Start is called before the first frame update
    void Start()
    {
        canWalking = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (canWalking == true)
        {
            canWalking.SetBool("canWalking", true);
            if (canWalking != null)
            {
                isWalking = false;
            }
        }
    }
}
