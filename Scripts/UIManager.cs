using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;

    GameManager gm;

    private void Start()
    {
        gm = GameManager.instance;
    }

    private void OnGUI()
    {
        scoreUI.text = GameManager.instance.prettyScore();
    }
}