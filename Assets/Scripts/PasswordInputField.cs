


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PasswordInputField : MonoBehaviour

{

    public DifficultyMAnager dm;
    public CoinCounter cc;


    public InputField inputfield;

    public void CheckInput()
    {
        if (inputfield.text == "c9s")      // check inputfield contains the string password - casper
        {
            Debug.Log("Password accepted");
            print("bra");
            dm.gameObject.GetComponent<DifficultyMAnager>().hardIsUnlock = true;
            dm.gameObject.GetComponent<DifficultyMAnager>().impossibleisUnlock = true;
            dm.gameObject.GetComponent<DifficultyMAnager>().hardIsBeat = true;
            dm.gameObject.GetComponent<DifficultyMAnager>().mediumIsBeat = true;
            cc.IncreaseCoins(10000);

        }
        else
        {
            print("wrong");
        }
    }

    private void Start()
    {
        cc = FindObjectOfType<CoinCounter>();
    }
}



