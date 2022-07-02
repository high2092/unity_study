using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO currentWave;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    public WaveConfigSO GetCurrentWave() {
        return currentWave;
    }

    IEnumerator SpawnEnemies() {
        for (int i = 0; i < currentWave.GetEnemyCount(); i++) {
            Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWaypoint().position, Quaternion.identity, transform);
            yield return new WaitForSeconds(currentWave.GetSpawnTime());
        }
    }
}
