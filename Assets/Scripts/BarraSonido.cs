using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraSonido : MonoBehaviour
{
    [SerializeField] Slider VolumenSlider;
    // Start is called before the first frame update

    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }

        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume =  VolumenSlider.value;
        save();
    }

    private void Load()
    {
        VolumenSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void save()
    {
        PlayerPrefs.SetFloat("musicVolume", VolumenSlider.value);

    }


}
