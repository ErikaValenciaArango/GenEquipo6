using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    Rigidbody2D rgbdPlayer;
    public float jumpForce = 1000;
    private bool tocaSuelo;
    public float speed;
    public GameObject bullet;
    public GameObject pointShot;
    public float tiempoParaDisparar;
    public float tiempoActual;
    void Start()
    {
        rgbdPlayer = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        tiempoActual += Time.deltaTime;

        //Salto del personaje
        if ( Input.GetKeyDown(KeyCode.Space)&& tocaSuelo)
        {
            rgbdPlayer.velocity = Vector3.zero;
            rgbdPlayer.AddForce(transform.up * jumpForce , ForceMode2D.Impulse );
            tocaSuelo = false;
        }

        //Disparar proyectil
        if (Input.GetKeyDown(KeyCode.F) && tiempoActual >= tiempoParaDisparar)
          
        {
            Shot();
            tiempoActual = 0;
        }

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Evita saltar mas de una vez
        if (collision.gameObject.CompareTag("Suelo"))
        {
            tocaSuelo = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //Evita saltar mas de una vez
        if (collision.gameObject.CompareTag ("Suelo"))
        {
            tocaSuelo = false;
        }
    }

    private void Shot() 
    {
        //Creacion de proyectiles
        Instantiate(bullet, pointShot.transform.position, Quaternion.identity);
    }
}
