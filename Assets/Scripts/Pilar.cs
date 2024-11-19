using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilar : MonoBehaviour
{
    public GameObject Camera; // Cámara a la que seguimos
    public float parallaxSpeed; // Velocidad del movimiento
    private float length; // Ancho del fondo
    private float startPos; // Posición inicial del fondo

    void Start()
    {
        startPos = transform.position.x; // Posición inicial
        length = GetComponent<SpriteRenderer>().bounds.size.x; // Calculamos el ancho del fondo
        
    }

    void Update()
    {
        parallaxSpeed = globals.Instance.everythingSpeed * 0.5f; // Velocidad del movimiento
        // Calcula el desplazamiento basado en el tiempo transcurrido
        float distance = Time.deltaTime * parallaxSpeed;

        // Mueve el fondo hacia la izquierda constantemente
        transform.position = new Vector3(transform.position.x - distance, transform.position.y, transform.position.z);

        // Verifica si el fondo ha salido completamente del campo de visión hacia la izquierda
        if (transform.position.x < Camera.transform.position.x - length)
        {
            Debug.Log("Fondo reciclado");
            // Reubica el fondo al lado derecho
            transform.position = new Vector3(transform.position.x + 2 * length, transform.position.y, transform.position.z);
        }
    }
}

