using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.transform.position = new Vector3(Random.value * 20 - 10, 1.51f, Random.value * 20 - 10);
        }
    }
}
