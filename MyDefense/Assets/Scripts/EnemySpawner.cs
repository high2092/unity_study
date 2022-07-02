using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float waveDelay = 0f;
    WaveConfigSO currentWave;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemyWaves());
    }

    public WaveConfigSO GetCurrentWave() {
        return currentWave;
    }

    IEnumerator spawnEnemyWaves() {
        for (int i = 0; i < waveConfigs.Count; i++) {
            currentWave = waveConfigs[i];
            for (int j = 0; j < currentWave.GetEnemyCount(); j++) {
                Instantiate(currentWave.GetEnemyPrefab(j), currentWave.GetStartingWaypoint().position, Quaternion.identity, transform);
                yield return new WaitForSeconds(currentWave.GetSpawnTime());
            }
            yield return new WaitForSeconds(waveDelay);
        }
    }
}
