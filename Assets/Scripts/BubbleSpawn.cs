using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawn : MonoBehaviour
{
    public GameObject coinPrefab;
    public Vector3 minPosition;
    public Vector3 maxPosition;
    public int numberOfCoins = 10;
    public int coinsToCollect = 5; // Number of coins to collect before despawning
    public float spawnInterval = 1f; // Time interval between spawns
    public float despawnDelay = 5f; // Time delay before despawning coins

    private int coinsCollected = 0;

    void Start()
    {
        SpawnCoins(); // Spawn initial coins
        StartCoroutine(SpawnCoinsRepeatedly());
    }

    IEnumerator SpawnCoinsRepeatedly()
    {
        while (true)
        {
            // Wait until enough coins have been collected
            while (coinsCollected < coinsToCollect)
            {
                yield return null;
            }

            SpawnCoins();

            // Reset the number of coins collected
            coinsCollected = 0;

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnCoins()
    {
        for (int i = 0; i < numberOfCoins; i++)
        {
            float randomX = Random.Range(minPosition.x, maxPosition.x);
            float randomY = Random.Range(minPosition.y, maxPosition.y);
            float randomZ = Random.Range(minPosition.z, maxPosition.z);
            Vector3 spawnPosition = new Vector3(randomX, randomY, randomZ);

            // Spawn coin
            GameObject coin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);

            // Start coroutine to destroy the coin after despawnDelay
            // StartCoroutine(DestroyCoin(coin));
        }
    }

    IEnumerator DestroyCoin(GameObject coin)
    {
        yield return new WaitForSeconds(despawnDelay);

        // Check if the coin is still active (not collected)
        if (coin != null && coin.activeSelf)
        {
            coinsCollected++;
            Destroy(coin);
        }
    }
}
