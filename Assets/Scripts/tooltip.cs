using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class tooltip : MonoBehaviour
{

    public static tooltip _instance;

   public TMPro.TextMeshProUGUI textComponent; 

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this; 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
    }
    // useless script abandond project -casper.
    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;  
    }

    public void SetAndShowToolTip(string message)
    {
        gameObject.SetActive(true);
        textComponent.text = message;
    }

    public void HideToolTip()
    {
        gameObject.SetActive(false);
        textComponent.text = string.Empty;
    }
}
