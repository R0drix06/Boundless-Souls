using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musicaMenu : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayBackgroundMusic(bool toggleBackgroundMusic)
    {
        if (toggleBackgroundMusic)
        {
           
            PlayerPrefs.SetInt("musicaPlay", 0);


        }
        else
        {
         
            PlayerPrefs.SetInt("musicaPlay", 1);

        }
    }

    public void cerrarMenu()
    {

        SceneManager.LoadScene("MainMenu");

    }
}
