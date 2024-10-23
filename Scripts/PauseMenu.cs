using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            pause();
        }
    }

    public void pause()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void resumeGame()
    {
        Time.timeScale = 1.0f;
        pausePanel.SetActive(false);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
}