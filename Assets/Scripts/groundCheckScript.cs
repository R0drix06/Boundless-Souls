using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheckScript : MonoBehaviour
{
    [SerializeField] public bool generateGround = true;
    [SerializeField] public bool generateCieling = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

     void OnCollision2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            generateGround = false;
            print("hola si soy yo");
        }

        if (collision.gameObject.CompareTag("Ceiling"))
        {
            generateCieling = false;
            print("hola si");
        }
    }
}
