using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globals : MonoBehaviour
{


    public static globals Instance;
    public float everythingSpeed;
    public float dischargeRate;

    public bool perder = false;

    private void Awake()
    {
        everythingSpeed = 5f;
        dischargeRate = 5f;

        if (Instance == null)
        {
            Instance = this;
            
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
            everythingSpeed += 0.15f * Time.deltaTime;
        }
        if (dischargeRate <= 15)
        {
            dischargeRate += 0.2f * Time.deltaTime;
        }

    }
}
