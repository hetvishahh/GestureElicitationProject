using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public float speed = 1.0f; // Speed of cube's movement
    public float delay = 3.0f; // Delay before cube starts moving 
    public float moveDistance = 5.0f; // Distance cube will move before stopping

    private Vector3 initialPosition; // To store the initial position of the cube
    private Coroutine currentMovement; // To keep track of the current movement coroutine

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position; // Store the initial position of the cube
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            StartMovement(Vector3.up); // Move up
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            StartMovement(Vector3.down); // Move down
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            StartMovement(Vector3.left); // Move left
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            StartMovement(Vector3.right); // Move right
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            StartMovement(Vector3.forward); // Move forward (towards you)
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            StartMovement(Vector3.back); // Move backward (away from you)
        }
    }

    // this will make sure the position of the cube is back in the correct place 
    void StartMovement(Vector3 direction)
    {
        if (currentMovement != null)
        {
            StopCoroutine(currentMovement); // Stop any ongoing movement
            transform.position = initialPosition; // Reset position to initial
        }
        currentMovement = StartCoroutine(MoveCube(direction));
    }

    IEnumerator MoveCube(Vector3 direction)
    {
        float totalMovement = 0;
        while (totalMovement < moveDistance)
        {
            float step = speed * Time.deltaTime;
            transform.Translate(direction * step);
            totalMovement += step;
            yield return null;
        }

        // Teleport cube back to its initial position
        transform.position = initialPosition;
    }
}
