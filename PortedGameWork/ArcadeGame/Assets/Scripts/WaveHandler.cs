using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using TMPro;
using UnityEngine;

public class WaveHandler : MonoBehaviour
{
    public GameObject[] spawners;

    [Header("Text")]
    public TMP_Text waveStartedText;
    public TMP_Text waveEndedText;

    [Header("Enemies")]
    public GameObject[] slimes;

    [Header("Settings")]
    public int waveStartedTextTime = 3; // How long the wave started text shows for
    public float waveCooldown = 7;
    public float waveEnemyCount = 4; // Number of enemies per wave, inital number is the amount of enemies on the first wave
    public float waveNumber = 0; // Number of waves passed
    public float waveEnemyMultiplier = 1.15f;
    public float spawnDelay = 0.2f;
    public GameObject waveReward; // Reward for completeing a wave

    GameObject[] localSlimes;
    float waveStartTime;
    float nextWaveTime;
    int enemyCount = 1;

    void Start()
    {
        localSlimes = new GameObject[4];

        localSlimes[0] = slimes[0];
        localSlimes[1] = slimes[0];
        localSlimes[2] = slimes[0];
        localSlimes[3] = slimes[0];

        StartWave();
    }

    void Update()
    {
        if (enemyCount == 0 && Time.time >= nextWaveTime) // Check if there are no enemies and wave cooldown is over
        {
            StartWave();

        }

        if (Time.time >= waveStartTime) // If enough time has passed hide the wave started text
        {
            waveStartedText.gameObject.SetActive(false);
        }
    }
    private IEnumerator SpawnWave(int waveAmount)
    {
        for (int i = 0; i < waveAmount; i++)
        {
            GameObject newSlime = Instantiate(localSlimes[Random.Range(0, localSlimes.Length)]);

            newSlime.transform.position = GetRandomPosition();

            enemyCount++;

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void StartWave()
    {
        waveEndedText.gameObject.SetActive(false);
        waveStartedText.gameObject.SetActive(true);

        waveStartTime = Time.time + waveStartedTextTime;

        enemyCount = 0;

        float newWaveEnemyAmount = waveEnemyCount * Mathf.Pow(waveEnemyMultiplier, waveNumber);

        StartCoroutine(SpawnWave(Mathf.RoundToInt(newWaveEnemyAmount)));
    }
    void AdjustDifficulty() // Scale difficulty by introducing different slimes at different points in the game
    {
        if (waveNumber == 1)
        {
            localSlimes[1] = slimes[1];
        }

        if (waveNumber == 3)
        {
            localSlimes[2] = slimes[2];
        }

        if (waveNumber == 5)
        {
            localSlimes[3] = slimes[3];
        }
    }

    Vector3 GetRandomPosition()
    {
        GameObject randomSpawner = spawners[Random.Range(0, spawners.Length)];

        return randomSpawner.transform.position;
    }

    public void decreaseEnemyCount()
    {
        enemyCount--;

        if (enemyCount == 0)
        {
            nextWaveTime = Time.time + waveCooldown;

            waveNumber++;
            AdjustDifficulty();

            waveEndedText.gameObject.SetActive(true);

            GameObject reward = Instantiate(waveReward);
            reward.transform.position = Vector3.zero;
        }
    }
}
