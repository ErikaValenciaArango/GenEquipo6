using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllBullet : MonoBehaviour
{

    public float speed = 5;
    private MovePlayer playerControllerScript;
    private float rightBound = 11;
    public AudioClip destroyClip;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<MovePlayer>();
    }
    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
            transform.Rotate(Vector3.forward);
        }

        // If object goes off screen that is NOT the background, destroy it
        if (transform.position.x > rightBound && !gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.CompareTag("Obstacle")){
            Debug.Log("Colision");
            Destroy(gameObject);
            Destroy(other.gameObject);
            AudioManager.Instance.PlaySFX(destroyClip);
        }
    }
}
