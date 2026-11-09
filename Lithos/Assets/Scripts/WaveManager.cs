
using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour
{
    [Header("Wave Settings")]
    [SerializeField] private WaveData[] waves;
    [SerializeField] private Transform spawnNode;

    private int currentWave = 0;
    private int aliveEnemies = 0;

    private bool isSpawning = false;
    private bool waveInProgress = false;

    public void StartNextWave()
    {
        if (waveInProgress || currentWave >= waves.Length)
            return;

        waveInProgress = true;

        StartCoroutine(SpawnWave(waves[currentWave]));

        currentWave++;
    }

    private IEnumerator SpawnWave(WaveData wave)
    {
        isSpawning = true;

        foreach (EnemySpawnData group in wave.enemies)
        {
            for (int i = 0; i < group.amount; i++)
            {
                GameObject enemy = Instantiate(group.enemyPrefab, spawnNode.position, Quaternion.identity);
                RegisterEnemy();

                if (i < group.amount - 1)
                {
                    yield return new WaitForSeconds(group.spawnInterval);
                }
            }
        }

        isSpawning = false;

        CheckWaveComplete();
    }

    public void EnemyDestroyed()
    {
        aliveEnemies--;
        CheckWaveComplete();
    }

    public void RegisterEnemy()
    {
        aliveEnemies++;
    }

    private void CheckWaveComplete()
    {
        if (!isSpawning && aliveEnemies <= 0 && waveInProgress)
        {
            waveInProgress = false;
            Debug.Log("wave finished");

            StartNextWave();
        }
    }

    void Start()
    {
        StartNextWave();
    }
}
