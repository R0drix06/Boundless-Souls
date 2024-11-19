using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class boolMusica : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        if(PlayerPrefs.GetInt("musicaPlay")== 0)
        {

           GetComponent<Toggle>().isOn = true;

        }else if (PlayerPrefs.GetInt("musicaPlay") == 1)
        {

            GetComponent<Toggle>().isOn = false;
        }
     
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
