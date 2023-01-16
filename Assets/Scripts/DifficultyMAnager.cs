using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyMAnager : MonoBehaviour
{
    public bool mediumIsBeat = false;
    public bool hardIsBeat = false;
    public bool hardIsUnlock = false;
    public bool bossDeadMedium = false;
    public bool bossDeadHard = false;
    public bool impossibleisUnlock = false;
    public GameObject hardbutton;
    public GameObject impossibleButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bossDeadMedium == true)
        {
            mediumIsBeat = true; 
        }


        if (mediumIsBeat == true)
        {
            hardIsUnlock = true; 
        }

        if (bossDeadHard == true)
        {
            impossibleisUnlock = true;
        }

        if (hardIsUnlock == false)
        {
            hardbutton.SetActive(false); 
        }

        if (impossibleisUnlock == false)
        {
            impossibleButton.SetActive(false);
        }
    }
}