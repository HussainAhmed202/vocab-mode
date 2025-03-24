using UnityEngine;

public class MoveArrow : MonoBehaviour
{

    private float speed = 2f; // Speed of the movement
    private float height = 0.5f; // Maximum height variation

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position; // Store the initial position
    }

    void Update()
    {
        // Move the sprite up and down using a sine wave
        transform.position = startPos + new Vector3(0, Mathf.Sin(Time.time * speed) * height, 0);
    }
}
