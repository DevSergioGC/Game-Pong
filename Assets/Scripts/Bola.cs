using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bola : MonoBehaviour
{

    //Velocidad
    public float velocidad = 30.0f;

    public int golesIzquierda, golesDerecha = 0;

    AudioSource fuenteDeAudio;

    public AudioClip audioGol, audioRaqueta, audioRebote;

    public Text contadorIzquierda, contadorDerecha;   

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;

        fuenteDeAudio = GetComponent<AudioSource>();

        contadorIzquierda.text = golesIzquierda.ToString();
        contadorDerecha.text = golesDerecha.ToString();
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D micolision)
    {

        if (micolision.gameObject.name == "RaquetaIzquierda")
        {

            int x = 1;
            int y = direccionY(transform.position, micolision.transform.position);

            Vector2 direccion = new Vector2(x,y);

            GetComponent<Rigidbody2D>().velocity = direccion * velocidad;

            fuenteDeAudio.clip = audioRaqueta;
            fuenteDeAudio.Play();         

        }

        if (micolision.gameObject.name == "RaquetaDerecha")
        {
            int x2 = -1;
            int y2 = direccionY(transform.position, micolision.transform.position);

            Vector2 direccion2 = new Vector2(x2, y2);
            GetComponent<Rigidbody2D>().velocity = direccion2 * velocidad;

            fuenteDeAudio.clip = audioRaqueta;
            fuenteDeAudio.Play();
        }

        if (micolision.gameObject.name == "Arriba" || micolision.gameObject.name == "Abajo")
        {
            fuenteDeAudio.clip = audioRebote;
            fuenteDeAudio.Play();
        }

        int direccionY(Vector2 posicionBola, Vector2 posicionRaqueta)
        {
            if (posicionBola.y > posicionRaqueta.y)
            {
                return 1;
            }
            else if (posicionBola.y < posicionRaqueta.y)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }       

    }

    public void reiniciarBola(string direccion)
    {
        transform.position = Vector2.zero;

        velocidad += 5;

        if (golesDerecha == 4 || golesIzquierda == 4)
        {
            fuenteDeAudio.clip = audioGol;
            fuenteDeAudio.Play();
            fuenteDeAudio.Play();
            Application.Quit();
        }
        else
        {
            if (direccion == "Derecha")
            {
                golesDerecha++;
                contadorDerecha.text = golesDerecha.ToString();
                GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;
            }
            else if (direccion == "Izquierda")
            {
                golesIzquierda++;
                contadorIzquierda.text = golesIzquierda.ToString();
                GetComponent<Rigidbody2D>().velocity = Vector2.left * velocidad;
            }

            fuenteDeAudio.clip = audioGol;
            fuenteDeAudio.Play();
        }     
    }    
}
