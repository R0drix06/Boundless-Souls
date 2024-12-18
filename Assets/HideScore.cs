using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HideScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] int puntaje;

    void Update()
    {

        puntaje = PlayerPrefs.GetInt("Highestscore");


        score.text = "Highest Score: " + puntaje;

    }
}
