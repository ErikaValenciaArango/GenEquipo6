using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawn;
    public float minTime = 1f, maxTime = 1.9f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    // Update is called once per frame
    void Update()
    {
       if(GameObject.Find("Player").GetComponent<MovePlayer>().gameOver){
        StopAllCoroutines();
       }
    }

    private IEnumerator SpawnObstacle()
    {
        while (true)
        {
            //Creacion de enemigos
            int randomindex = Random.Range(0, spawn.Length);
            
            float randomTime = Random.Range(minTime, maxTime);

            Instantiate(spawn[randomindex], new Vector2(transform.position.x, spawn[randomindex].transform.position.y),spawn[randomindex].transform.rotation);
            yield return new WaitForSeconds(randomTime);
        }
    }

}
