using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public GameObject spawnPrefab;
    public int spawnInterval;
    public int spawnIntervalVariance;
    public int initialEnemies;

    [SerializeField]
    private int currentSpawnInterval;

    [SerializeField]
    private List<Transform> spawns;

    private void Awake()
    {
        spawns = new List<Transform>();
        SetNextSpawnInterval();
    }

    private void Start()
    {
        for (int i = 0; i < initialEnemies; i++)
        {
            SpawnEnemy();
        }
        StartCoroutine(SpawnTimer());
    }

    private void SetNextSpawnInterval()
    {
        int spawnIntervalLow = spawnInterval - spawnIntervalVariance;
        if (spawnIntervalLow < 1)
            spawnIntervalLow = 1;

        int spawnIntervalHigh = spawnInterval + spawnIntervalVariance;

        currentSpawnInterval = Random.Range(spawnIntervalLow, spawnIntervalHigh);
    }

    public void AddSpawn(Transform spawn)
    {
        spawns.Add(spawn);
    }

    private void SpawnEnemy()
    {
        int count = 0;
        while (true)
        {
            count++;
            if (count > 5)
                return;

            var spawn = GetRandomSpawnPoint();
            if (SpawnCheck(spawn))
            {
                Debug.Log("spawning enemy");
                Instantiate(spawnPrefab, spawn.position, Quaternion.identity);
                return;
            }
        }
    }

    private Transform GetRandomSpawnPoint()
    {
        int randomSpawnId = Random.Range(0, spawns.Count);
        return spawns[randomSpawnId];
    }

    private bool SpawnCheck(Transform transform)
    {
        var enemies = GameObject.FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        foreach (Enemy enemy in enemies)
        {
            if (Vector2.Distance(transform.position, enemy.transform.position) < 5)
                return false;
        }
        return true;
    }

    IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(currentSpawnInterval);
        SpawnEnemy();
        SetNextSpawnInterval();
        StartCoroutine(SpawnTimer());
    }
}
