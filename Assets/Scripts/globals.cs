using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globals : MonoBehaviour
{

    private float limiteVelocidad = 12f;
    private float aceleracion = 0.15f;

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
        
        if (everythingSpeed <= limiteVelocidad)
        {
            everythingSpeed += aceleracion * Time.deltaTime;
        }
        if (dischargeRate <= 15)
        {
            dischargeRate += 0.2f * Time.deltaTime;
        }

    }
}
