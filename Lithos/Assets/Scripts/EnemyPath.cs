using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    public Transform[] nodes;

    void Awake()
    {
        nodes = GetComponentsInChildren<Transform>();
        
        nodes = nodes[1..];
    }
}
