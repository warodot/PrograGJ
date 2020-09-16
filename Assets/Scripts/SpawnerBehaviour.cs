using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehaviour : MonoBehaviour
{
    public GameObject cositaPrefab;

    public float maxTime;
    public float timeToSpawn = 5;
    float spawnTimer;

    public float maxHorizontalSpawnerLenght = 7;
    public float minHorizontalSpawnerLenght = -7;

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.GameState == EGameState.ONGOING)
        {
            spawnTimer += Time.deltaTime;

            if(spawnTimer > timeToSpawn)
            {
                Vector3 randomPos = new Vector3(Random.Range(minHorizontalSpawnerLenght,maxHorizontalSpawnerLenght),transform.position.y,0);
                Instantiate(cositaPrefab,randomPos, Quaternion.identity);

                spawnTimer = 0;
            }
        }
    }
}
