using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raqueta : MonoBehaviour
{

    //Velocidad
    public float velocidad = 30.0f;

    //Eje Vertical
    public string eje;
    
    void FixedUpdate()
    {

        float v = Input.GetAxisRaw(eje);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v * velocidad);

    }
}
