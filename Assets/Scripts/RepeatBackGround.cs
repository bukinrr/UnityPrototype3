using UnityEngine;

public class RepeatBackGround : MonoBehaviour
{
    private float RepeatWidth;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        RepeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    void Update()
    {
        if (transform.position.x < startPos.x - RepeatWidth)
        {
            transform.position = startPos;
        }
    }
}