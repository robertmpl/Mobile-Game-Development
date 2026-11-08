using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Transform[] nodes;

    void Awake()
    {
        nodes = GetComponentsInChildren<Transform>();

        nodes = nodes[1..];
    }
}
