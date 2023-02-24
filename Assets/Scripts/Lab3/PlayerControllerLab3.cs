using UnityEngine;

public class PlayerControllerLab3 : MonoBehaviour
{
    private float PlayerSpeed = 2f;
    private float board = 9.4f;
    private Rigidbody playerRigidbody;


    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerMovement();
        LimitationMovement();
    }

    private void PlayerMovement()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalMove, 0, verticalMove);
        playerRigidbody.AddForce(movement * PlayerSpeed);
    }

    private void LimitationMovement()
    {
        if (transform.position.x > board || transform.position.x < -board)
        {
            if (transform.position.x >= 0)
                transform.position = new Vector3(board, transform.position.y, transform.position.z);
            else
                transform.position = new Vector3(-board, transform.position.y, transform.position.z);
        }

        if (transform.position.z > board || transform.position.z < -board)
        {
            if (transform.position.z >= 0)
                transform.position = new Vector3(transform.position.x, transform.position.y, board);
            else
                transform.position = new Vector3(transform.position.x, transform.position.y, -board);
        }
    }
}