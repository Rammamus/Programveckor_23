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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
