using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    Rigidbody2D rgbdPlayer;
    public float jumpForce = 1000;
    private bool tocaSuelo;
    private float horizontal;
    public float speed;
    public bool gameOver =false;
    void Start()
    {
        rgbdPlayer = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (horizontal != 0)
        {
            transform.Translate(new Vector3(horizontal * speed * Time.deltaTime, 0, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space) && tocaSuelo)
        {
            rgbdPlayer.velocity = Vector3.zero;

            rgbdPlayer.AddForce(transform.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
            tocaSuelo = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            tocaSuelo = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            tocaSuelo = false;
        }
    }
}
