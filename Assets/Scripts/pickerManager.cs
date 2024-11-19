using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pickerManager : MonoBehaviour
{
    [SerializeField] private GameObject pickerTop;
    [SerializeField] private GameObject pickerBottom;

    private bool isTop;
    private bool isBottom;


    // Start is called before the first frame update
    void Start()
    {
        isTop = true;
        isBottom = false;
        
    }
    private void Awake()
    {
        isTop = true;
        isBottom = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTop && ((Input.GetKeyDown(KeyCode.S)) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.DownArrow)|| Input.GetKeyDown(KeyCode.UpArrow)))
        {
            isTop = false;
            isBottom = true;
        }
        else if (isBottom && ((Input.GetKeyDown(KeyCode.S)) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            isTop = true;
            isBottom = false;
        }

        if (isTop)
        {
            pickerBottom.SetActive(false);
            pickerTop.SetActive(true);
        }

        if (isBottom)
        {
            pickerBottom.SetActive(true);
            pickerTop.SetActive(false);
        }

        if (isTop && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))) { 
        
        SceneManager.LoadScene("Game");
        }

        if (isBottom && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)))
        {

            SceneManager.LoadScene("opciones");

        }



    }
}
