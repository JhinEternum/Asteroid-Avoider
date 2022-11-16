using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] asteroidPrefabs;

    [SerializeField] private float spawnDelay = 1.5f;

    [SerializeField] private Vector2 forceRange;

    private int counter;

    private float timer;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnAsteroid();

            timer += spawnDelay;

            counter++;
        }

        if (counter >= 20)
        {
            spawnDelay = 1f;
        }
        if (counter >= 50)
        {
            spawnDelay = 0.5f;
        }
    }

    private void SpawnAsteroid()
    {
        int side = Random.Range(0, 4);

        Vector2 spawnPoint = Vector2.zero;
        Vector2 direction = Vector2.zero;

        float angleRange = Random.Range(-1f, 1f);

        switch (side)
        {
            //  Left
            case 0:
                spawnPoint.x = 0f;
                spawnPoint.y = Random.value;
                direction = new Vector2(1f, angleRange);
                break;
            //  Right
            case 1:
                spawnPoint.x = 1f;
                spawnPoint.y = Random.value;
                direction = new Vector2(-1f, angleRange);
                break;
            //  Bottom
            case 2:
                spawnPoint.x = Random.value;
                spawnPoint.y = 0f;
                direction = new Vector2(angleRange, 1f);
                break;
            // Top
            case 3:
                spawnPoint.x = Random.value;
                spawnPoint.y = 1f;
                direction = new Vector2(angleRange, -1f);
                break;
        }

        Vector3 worldSpawnPoint = mainCamera.ViewportToWorldPoint(spawnPoint);
        worldSpawnPoint.z = 0;

        GameObject selectedAsteroid = asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)];

        Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

        GameObject asteroidInstance = Instantiate(selectedAsteroid, worldSpawnPoint, rotation);

        Rigidbody rb = asteroidInstance.GetComponent<Rigidbody>();
        rb.velocity = direction.normalized * Random.Range(forceRange.x, forceRange.y);
    }

}
