


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PasswordInputField : MonoBehaviour

{

    public DifficultyMAnager dm;


    public InputField inputfield;

    public void CheckInput()
    {
        if (inputfield.text == "c9s")      // check inputfield contains the string password
        {
            Debug.Log("Password accepted");
            print("bra");
            dm.hardIsUnlock = true;
            dm.impossibleisUnlock = true;
        }
    }
}



