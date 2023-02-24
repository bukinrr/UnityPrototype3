using UnityEngine;

public class moveLeft : MonoBehaviour
{
    private enum ModeGame
    {
        Standart,
        Speed
    }

    [SerializeField] private float speed;
    private PlayerController PlayerControllerScript;
    private float leftBound = -10;
    private ModeGame GameStatus = ModeGame.Standart;

    private void Start()
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            ChangeModeGame();
        }
        DestroyObstacle();
        GameOver();
    }

    private void ChangeModeGame()
    {
        if (GameStatus == ModeGame.Standart)
        {
            GameStatus = ModeGame.Speed;
            speed *= 2;
            Debug.Log(GameStatus);
        }
        else
        {
            GameStatus = ModeGame.Standart;
            speed /= 2;
            Debug.Log(GameStatus);
        }
    }

    private void DestroyObstacle()
    {
        if (transform.position.x < leftBound && transform.CompareTag("Obstacle"))
            Destroy(gameObject);
    }

    private void GameOver()
    {
        if (PlayerControllerScript.GameOver == false)
            transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}