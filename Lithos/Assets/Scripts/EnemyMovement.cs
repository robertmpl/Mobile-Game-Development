using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] public float enemySpeed = 1.0f;

    private EnemyPath enemyPath;
    private Transform[] nodes;

    private int currentNode = 0;

    void Awake()
    {
        enemyPath = GameObject.Find("EnemyPath").GetComponent<EnemyPath>();
    }

    void Start()
    {
        nodes = enemyPath.nodes;   
    }

    void Update()
    {
        if (currentNode >= nodes.Length)
            return;

        Transform targetNode = nodes[currentNode];

        transform.position = Vector2.MoveTowards(transform.position, targetNode.position, enemySpeed * Time.deltaTime);

        if (transform.position == targetNode.position)
        {
            currentNode++;
        }
    }
}
