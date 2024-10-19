using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private IEnumerator SpawnObstacle()
    {
        while (true)
        {
            //Creacion de enemigos
            int randomindex = Random.Range(0, spawn.Length);
            float minTime = 0.6f;
            float maxTime = 1.8f;
            float randomTime = Random.Range(minTime, maxTime);

            Instantiate(spawn[randomindex], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(randomTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destruir enemigo al momento de contactar con algun objeto
        Destroy(collision.gameObject);
    }
}
