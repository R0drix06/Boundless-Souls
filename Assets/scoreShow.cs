using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scoreShow : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] int puntaje; 

    void Update()
    {

        puntaje = PlayerPrefs.GetInt("RunScore");

       
            score.text = "Score: " + puntaje;
        
    }
}
