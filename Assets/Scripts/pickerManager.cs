using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pickerManager : MonoBehaviour
{
    [SerializeField] private GameObject pickerTop;
    [SerializeField] private GameObject pickerBottom;
    [SerializeField] private GameObject pickerMid; 

    private bool isTop;
    private bool isBottom;
    private bool isMid; 


    // Start is called before the first frame update
    void Start()
    {
        isTop = true;
        isBottom = false;
        isMid = false;
        
    }
    private void Awake()
    {
        isTop = true;
        isBottom = false;
        isMid = false;
    }

    // Update is called once per frame
    void Update()
    {

        /// apreta la S o flecha abajo 
        if (isTop && ((Input.GetKeyDown(KeyCode.S)) || Input.GetKeyDown(KeyCode.DownArrow)))
        {
            isTop = false;
            isBottom = false;
            isMid = true;
        }
        else if (isBottom && ((Input.GetKeyDown(KeyCode.S)) || Input.GetKeyDown(KeyCode.DownArrow)))
        {
            isTop = true;
            isMid= false;
            isBottom = false;
        }

        else if (isMid && ((Input.GetKeyDown(KeyCode.S)) || (Input.GetKeyDown(KeyCode.DownArrow))))
        {
            isTop = false;
            isMid = false; 
            isBottom = true;
        }

        /// apreta la W o flecha arriba 
        else if (isTop && ((Input.GetKeyDown(KeyCode.W)) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            isTop = false;
            isBottom = true;
            isMid = false;
        }
        else if (isBottom && ((Input.GetKeyDown(KeyCode.W)) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            isTop = false;
            isMid = true;
            isBottom = false;
        }

        else if (isMid && ((Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.UpArrow))))
        {
            isTop = true;
            isMid = false;
            isBottom = false;
        }

        if (isTop)
        {
            pickerMid.SetActive(false);
            pickerBottom.SetActive(false);
            pickerTop.SetActive(true);
        }

        if (isBottom)
        {
            pickerMid.SetActive(false);
            pickerBottom.SetActive(true);
            pickerTop.SetActive(false);
        }

        if (isMid)
        {
            pickerMid.SetActive(true);
            pickerBottom.SetActive(false);
            pickerTop.SetActive(false);
        }

        if (isTop && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))) { 
        
        SceneManager.LoadScene("Game");
        }

        if (isBottom && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)))
        {

            Application.Quit();
        }

        if (isMid && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)))
        {

            SceneManager.LoadScene("opciones");

        }



    }
}
