using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private PlayerController PlayerControllerScript;
    [SerializeField] private GameObject[] obstaclePrefab;
    private float startDelay = 2, repeatDelay = 2;

    void Start()
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatDelay);
    }

    private void SpawnObstacle()
    {
        if (PlayerControllerScript.GameOver == false)
        {
            var randomObstacle = obstaclePrefab[Random.Range(0, 4)];
            var transformRandomObstacle = randomObstacle.transform;
            Instantiate(randomObstacle,
                new Vector3(25, transformRandomObstacle.position.y, transformRandomObstacle.position.z),
                transformRandomObstacle.rotation);
        }
    }
}