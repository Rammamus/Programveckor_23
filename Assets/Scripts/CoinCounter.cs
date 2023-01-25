using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Den som håller i Coins i shop - William

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;

    public TMPro.TextMeshProUGUI coinText;
    public int currentCoins = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        coinText.text = "COINS: " + currentCoins.ToString();
    }
    public void DecreaseCoins(int v)
    {
        currentCoins -= v;
        coinText.text = "COINS: " + currentCoins.ToString();
    }

    public void IncreaseCoins(int v)
    {
        currentCoins += v;
        coinText.text = "COINS: " + currentCoins.ToString();
    }

    private void Update()
    {
        coinText.text = "COINS: " + currentCoins.ToString();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncreaseCoins(5);
        }
    }
}
