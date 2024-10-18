using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    Rigidbody2D rgbdPlayer;
    public float jumpForce = 1000;
    void Start()
    {
        rgbdPlayer = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("hola");
            rgbdPlayer.AddForce(Vector2.up * Time.deltaTime * jumpForce, ForceMode2D.Impulse);
        }
    }
}
