using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager instance;

    [SerializeField] private GameObject GameOverPanel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    #endregion

    public float currentScore;

    public bool isPlaying;

    private void Update()
    {
        if (isPlaying)
        {
            currentScore += Time.deltaTime;
        }
    }

    public void gameOver()
    {
        currentScore = 0;
        isPlaying = false;
        GameOverPanel.SetActive(true);
    }

    public string prettyScore()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }
}
