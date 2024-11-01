﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftX : MonoBehaviour
{
    public float speed;
    private MovePlayer playerControllerScript;
    private float leftBound = -10;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<MovePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        // If game is over, move to the left
        if (!playerControllerScript.gameOver && !playerControllerScript.win)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }

        // If object goes off screen that is NOT the background, destroy it
        if (transform.position.x < leftBound && !gameObject.CompareTag("Background") && !gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }

        if (gameObject.CompareTag("Finish") && transform.position.x < leftBound)
        {
            playerControllerScript.Lost();
        }

    }

    
}
