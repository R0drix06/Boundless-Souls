using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startingFloorMovement : MonoBehaviour
{
    private float speed = 7.6f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(1 * Time.deltaTime * -speed, 0, 0);
    }
}
