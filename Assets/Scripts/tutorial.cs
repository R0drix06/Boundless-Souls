using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    [SerializeField] private RectTransform posicion;
    [SerializeField] private float movimiento = 1f;

    // Start is called before the first frame update
    void Start()
    {
        posicion= GetComponent<RectTransform>();
        //movimiento = (globals.Instance.everythingSpeed - 6);
    }

    // Update is called once per frame
    void Update()
    {

        movimiento += 0.2f * Time.deltaTime;

        // Obtener la posición actual
        Vector3 nuevaPosicion = posicion.position;

        // Modificar solo el eje X
        nuevaPosicion.x -= movimiento * Time.deltaTime;

        // Asignar la nueva posición al RectTransform
        posicion.position = nuevaPosicion;
    }
}
