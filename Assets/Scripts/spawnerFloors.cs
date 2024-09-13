using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerFloors : MonoBehaviour
{
    [SerializeField] private GameObject[] groundPrefabs;
    [SerializeField] private GameObject[] ceilingPrefabs;
    public float obstacleSpawnTime = 3.0f;
    public float timeUntilObstacleSpawn;
    public float obstacleSpeed = 7.25f;

    private void Update()
    {
        SpawnLoop();
        if (obstacleSpawnTime >= 0.75)
        {
            obstacleSpawnTime -= 0.05f * Time.deltaTime;
            obstacleSpeed += 0.175f * Time.deltaTime;
        }
        
    }

    private void SpawnLoop()
    {
        timeUntilObstacleSpawn += Time.deltaTime;

        if (timeUntilObstacleSpawn >= obstacleSpawnTime)
        {
            SpawnGround();
            SpawnCeiling();
            timeUntilObstacleSpawn = 0;
        }
    }

    private void SpawnGround()
    {
        GameObject groundToSpawn = groundPrefabs[Random.Range(0, groundPrefabs.Length)];
        GameObject spawnedGround = Instantiate(groundToSpawn, groundToSpawn.transform.position, Quaternion.identity);

        Rigidbody2D groundRB = spawnedGround.GetComponent<Rigidbody2D>();
        groundRB.velocity = Vector2.left * obstacleSpeed;
    }
    private void SpawnCeiling()
    {
        GameObject ceilingToSpawn = ceilingPrefabs[Random.Range(0, ceilingPrefabs.Length)];
        GameObject spawnedCeiling = Instantiate(ceilingToSpawn, ceilingToSpawn.transform.position, Quaternion.identity);

        Rigidbody2D ceilingRB = spawnedCeiling.GetComponent<Rigidbody2D>();
        ceilingRB.velocity = Vector2.left * obstacleSpeed;
    }
}
