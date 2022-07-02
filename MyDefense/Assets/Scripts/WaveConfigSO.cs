using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float spawnDelay = 1f;
    [SerializeField] float spawnDelayVariance = 0f; // 랜덤성

    public Transform GetStartingWaypoint() {
        return pathPrefab.GetChild(0);
    }
    
    public int GetEnemyCount() {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int idx) {
        return enemyPrefabs[idx];
    }

    public List<Transform> GetWaypoints() {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab) {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public float GetMoveSpeed() {
        return moveSpeed;
    }

    public float GetSpawnTime() {
        return Random.Range(spawnDelay - spawnDelayVariance, spawnDelay + spawnDelayVariance);
    }
}
