using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class impossibleSFX : MonoBehaviour
{

    public AudioSource myFx;
    public AudioClip hoverFx;

    public void HoverSound()
    {
        myFx.PlayOneShot(hoverFx);
    }

    public void StopAduio()
    {
        myFx.Stop();
    }
    
   

    

    

}


