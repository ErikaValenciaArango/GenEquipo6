using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    private Rigidbody2D rb;
    public float tiempoParaDestruir;
    public float tiempoActual;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        tiempoActual += Time.deltaTime;
        rb.velocity = Vector3.right * speed * Time.deltaTime;
        
        //Destruir proyectiles
        if(tiempoActual > tiempoParaDestruir)
        {
            Destroy(gameObject);
        }
   }
}
