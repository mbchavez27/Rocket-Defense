using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemyController : MonoBehaviour
{

    public GameObject[] enemies = new GameObject[1];
    public Transform[] spawnEnemy = new Transform[9];

    public float spawnRate, spawnDelay = 1f;

    void Start()
    {
        spawnRate = spawnDelay;
    }

    void Update()
    {
        spawnRate += 1 * Time.deltaTime;
        if (spawnRate >= spawnDelay)
        {
            spawnRate = 0;
            int spawnpos = Random.Range(0, 12);
            Instantiate(enemies[0], spawnEnemy[spawnpos].position, spawnEnemy[spawnpos].rotation);
        }
    }
}
