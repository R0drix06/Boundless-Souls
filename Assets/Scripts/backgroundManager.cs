using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] backgroundPrefab;
    [SerializeField] private SpriteRenderer[] midgroundPrefab;
    [SerializeField] private SpriteRenderer[] foregroundPrefab;

    public float spawnTime = 3.0f;
    public float timeUntilSpawn;
    public float backgroundSpeed = 7.25f;
    public float midgroundSpeed = 7.25f;
    public float foregroundSpeed = 7.25f;

    private void Update()
    {
        SpawnLoop();
        if (spawnTime >= 0.75)
        {
            spawnTime -= 0.05f * Time.deltaTime;
            backgroundSpeed += 0.175f * Time.deltaTime;
        }

    }

    private void SpawnLoop()
    {
        timeUntilSpawn += Time.deltaTime;

        if (timeUntilSpawn >= spawnTime)
        {
            //SpawnBackground();
            SpawnMidground();
            timeUntilSpawn = 0;
        }
    }

    private void SpawnBackground()
    {
        SpriteRenderer backgroundToSpawn = backgroundPrefab[Random.Range(0, backgroundPrefab.Length)];
        SpriteRenderer spawnedBackground= Instantiate(backgroundToSpawn, backgroundToSpawn.transform.position, Quaternion.identity);

        spawnedBackground.transform.Translate(0, -5 * backgroundSpeed * Time.deltaTime, 0);
       
    }
    private void SpawnMidground()
    {
        SpriteRenderer midgroundToSpawn = midgroundPrefab[Random.Range(0, midgroundPrefab.Length)];
        SpriteRenderer spawnedMidground = Instantiate(midgroundToSpawn, midgroundToSpawn.transform.position, Quaternion.identity);

        spawnedMidground.transform.Translate(0, -1 * midgroundSpeed * Time.deltaTime, 0);
    }
}
