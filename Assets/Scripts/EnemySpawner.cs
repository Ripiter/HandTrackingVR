using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float timeCount = 3f;

    public float minTime = 2;
    public float maxTime = 5f;

    public GameObject[] enemies;
    public Transform[] places;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeCount -= Time.deltaTime;
        if (timeCount < 0)
        {
            timeCount = Random.Range(minTime, maxTime);

            GameObject enemy = enemies[Random.Range(0, enemies.Length)];
            Transform spawnPos = places[Random.Range(0, places.Length)];

            enemy.GetComponent<EnemyScript>().speed = Random.Range(2, 6);

            Instantiate(enemy, spawnPos.position, Quaternion.identity);
        }
    }
}
