using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


 public class soundvolumeslider : MonoBehaviour
{  // fungerande ljudslider - Ocean 
    [SerializeField] Slider SliderVolume;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume")) 
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Loading();
        }
        else
        {
            Loading();
        }
    }
    //sound volume slider gör så att det sparas Ocean
    public void ChangeVolume()
    {
        AudioListener.volume = SliderVolume.value;
        SaveSetting();
    }

    private void Loading()
    {

        SliderVolume.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void SaveSetting()
    {

        PlayerPrefs.SetFloat("musicVolume", SliderVolume.value);
    }
}
