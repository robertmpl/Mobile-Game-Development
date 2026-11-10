using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] public float enemySpeed = 1.0f;
    private WaveManager waveManager;
    private EnemyPath enemyPath;
    private Transform[] nodes;

    private int currentNode = 0;

    void Awake()
    {
        enemyPath = GameObject.Find("EnemyPath").GetComponent<EnemyPath>();
        waveManager = GameObject.Find("WaveManager").GetComponent<WaveManager>();
    }

    void Start()
    {
        nodes = enemyPath.nodes;   
    }

    void Update()
    {
        if (currentNode >= nodes.Length)
        {
            waveManager.EnemyDestroyed();
            Destroy(gameObject); 
            return;
        }

        Transform targetNode = nodes[currentNode];

        transform.position = Vector2.MoveTowards(transform.position, targetNode.position, enemySpeed * Time.deltaTime);

        if (transform.position == targetNode.position)
        {
            currentNode++;
        }
    }
}
