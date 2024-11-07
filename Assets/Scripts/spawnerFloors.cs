using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerFloors : MonoBehaviour
{
    [SerializeField] private GameObject[] groundPrefabs;
    [SerializeField] private GameObject[] ceilingPrefabs;
    public float floorSpawnTime = 3.0f;
    public float timeUntilFloorSpawn;
    [SerializeField] private float floorSpeed;


    private void Start()
    {
        floorSpeed = globals.Instance.everythingSpeed;
    }
    private void Update()
    {
        SpawnLoop();
        if (floorSpawnTime >= 0.75)
        {
            floorSpawnTime -= 0.05f * Time.deltaTime;
            floorSpeed += 0.175f * Time.deltaTime;
        }
        
    }

    private void SpawnLoop()
    {
        timeUntilFloorSpawn += Time.deltaTime;

        if (timeUntilFloorSpawn >= floorSpawnTime)
        {
            SpawnGround();
            SpawnCeiling();
            timeUntilFloorSpawn = 0;
        }
    }

    private void SpawnGround()
    {
        GameObject groundToSpawn = groundPrefabs[Random.Range(0, groundPrefabs.Length)];
        GameObject spawnedGround = Instantiate(groundToSpawn, groundToSpawn.transform.position, Quaternion.identity);

  
    }
    private void SpawnCeiling()
    {
        GameObject ceilingToSpawn = ceilingPrefabs[Random.Range(0, ceilingPrefabs.Length)];
        GameObject spawnedCeiling = Instantiate(ceilingToSpawn, ceilingToSpawn.transform.position, Quaternion.identity);

    }
}
