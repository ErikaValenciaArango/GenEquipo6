using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnEnemy;
    [SerializeField] private GameObject spawnAmmo, memory;
    public float minTime = 1f, maxTime = 1.9f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObstacle());
        StartCoroutine(SpawnAmmo());
        Invoke("GameWin", 20);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<MovePlayer>().gameOver)
        {
            StopAllCoroutines();
            CancelInvoke();
        }
    }

    private IEnumerator SpawnObstacle()
    {
        while (true)
        {
            //Creacion de enemigos
            int randomindex = Random.Range(0, spawnEnemy.Length);

            float randomTime = Random.Range(minTime, maxTime);

            Instantiate(spawnEnemy[randomindex], new Vector2(transform.position.x, spawnEnemy[randomindex].transform.position.y), spawnEnemy[randomindex].transform.rotation);
            yield return new WaitForSeconds(randomTime);
        }
    }

    private IEnumerator SpawnAmmo()
    {
        while (true)
        {
            //Creacion de enemigos
            float randomTime = Random.Range(minTime, maxTime);
            randomTime *= 4.5f;

            Instantiate(spawnAmmo, new Vector2(transform.position.x, spawnAmmo.transform.position.y), spawnAmmo.transform.rotation);
            yield return new WaitForSeconds(randomTime);
        }
    }

    private void GameWin()
    {
        StopAllCoroutines();
        Instantiate(memory);
    }

}
