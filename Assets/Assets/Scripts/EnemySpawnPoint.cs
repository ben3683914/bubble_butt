using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    SpawnManager manager;

    private void Start()
    {
        manager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        manager.AddSpawn(transform);
    }
}
