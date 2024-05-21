using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public float speed = 1.0f; // Speed of cube's movement
    public float moveDistance = 5.0f; // Distance cube will move before stopping
    public float rotationSpeed = 100.0f; // Speed of cube's rotation

    private Vector3 initialPosition; // To store the initial position of the cube
    private Quaternion initialRotation; // To store the initial rotation of the cube
    private Coroutine currentMovement; // To keep track of the current movement coroutine
    private Coroutine currentRotation; // To keep track of the current rotation coroutine

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position; // Store the initial position of the cube
        initialRotation = transform.rotation; // Store the initial rotation of the cube
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
            StartMovement(Vector3.forward); // Move forward (zoom in)
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            StartMovement(Vector3.back); // Move backward (zoom out)
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            StartRotation(Vector3.right); // Rotate around x-axis
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            StartRotation(Vector3.up); // Rotate around y-axis
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            StartRotation(Vector3.forward); // Rotate around z-axis
        }
    }

    void StartMovement(Vector3 direction)
    {
        if (currentMovement != null)
        {
            StopCoroutine(currentMovement); // Stop any ongoing movement
            transform.position = initialPosition; // Reset position to initial
        }
        currentMovement = StartCoroutine(moveCube(direction));
    }

    IEnumerator moveCube(Vector3 direction)
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

    void StartRotation(Vector3 axis)
    {
        if (currentRotation != null)
        {
            StopCoroutine(currentRotation); // Stop any ongoing rotation
            transform.rotation = initialRotation; // Reset rotation to initial
        }
        currentRotation = StartCoroutine(RotateCube(axis));
    }

    IEnumerator RotateCube(Vector3 axis)
    {
        float angle = 0;
        while (angle < 360.0f)
        {
            float step = rotationSpeed * Time.deltaTime;
            transform.Rotate(axis * step);
            angle += step;
            yield return null;
        }

        // Reset cube rotation to initial position
        transform.rotation = initialRotation;
    }
}
