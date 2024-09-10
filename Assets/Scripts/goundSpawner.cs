using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] groundPrefabs;
    public float groundSpawnTime = 3.0f;
    public float timeUntilGroundSpawn;
    public float groundSpeed = 7.25f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        groundSpawnLoop();

        if (groundSpawnTime >= 0.75)
        {
            groundSpawnTime -= 0.05f * Time.deltaTime;
            groundSpeed += 0.175f * Time.deltaTime;
        }

    }

    private void groundSpawnLoop()
    {
        timeUntilGroundSpawn += Time.deltaTime;

        if (timeUntilGroundSpawn >= groundSpawnTime)
        {
            spawnGround();
            timeUntilGroundSpawn = 0;
        }
    }

    private void spawnGround()
    {
        GameObject groundToSpawn = groundPrefabs[Random.Range(0, groundPrefabs.Length)];
        GameObject spawnedGround = Instantiate(groundToSpawn, groundToSpawn.transform.position, Quaternion.identity, transform);
        spawnedGround.transform.position = new Vector2(transform.position.x, spawnedGround.transform.position.y);

        Rigidbody2D groundRB = spawnedGround.GetComponent<Rigidbody2D>();
        groundRB.velocity = Vector2.left * groundSpeed;
    }
}
