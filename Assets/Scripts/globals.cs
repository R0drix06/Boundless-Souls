using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globals : MonoBehaviour
{


    public static globals Instance;
    public float everythingSpeed = 7.5f;

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (everythingSpeed <= 12f)
        {
            everythingSpeed += 0.175f * Time.deltaTime;
        }
        
    }
}
