using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Tower Defence/Wave")]
public class WaveData : ScriptableObject
{
    public EnemySpawnData[] enemies;
}