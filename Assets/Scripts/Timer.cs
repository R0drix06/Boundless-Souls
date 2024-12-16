using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Net.Sockets;
using UnityEngine.SocialPlatforms.Impl;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField, Range(0.1f, 1f)] float timeScale = 0.5f; // Factor de velocidad del temporizador (0.5 = más lento, 1 = normal)
    float elapsedTime;

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime * 100; // Escala la velocidad del temporizador
        int score = Mathf.FloorToInt(elapsedTime); // Redondea a entero
        timerText.text = score.ToString("D6"); // Formatea con 6 dígitos (000001, 000002, ...)

        PlayerPrefs.SetInt("HighScore", score);
        PlayerPrefs.GetInt("HighScore");

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

    }
}
