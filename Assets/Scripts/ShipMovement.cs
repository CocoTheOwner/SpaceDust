using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    // The current velocity of the ship
    public Vector2 velocity = Vector2.zero;
    public float velocityMagnitude = 0;
    // Accelleration in the direction of the ship
    public float movementAcceleration = 1f;
    // Maximal speed of the ship. Places a bound on the magnitude of the velocity vector
    public float maxMovementSpeed = 10;

    // The current rotation speed of the ship in degrees per second
    public float rotationSpeed = 0;
    // The rotation acceleration of the ship in degrees per second per second
    public float rotationAcceleration = 15;
    // The maximal rotation speed of the ship in radians per second. Places a bound on the magnitude of the rotation speed
    public float maxRotationSpeed = 720;

    // Movement keys (list), with initial values
    public List<KeyCode> accelerateKeys = new List<KeyCode> { KeyCode.UpArrow, KeyCode.W };
    public List<KeyCode> decelerateKeys = new List<KeyCode> { KeyCode.DownArrow, KeyCode.S };
    public List<KeyCode> rotateLeftKeys = new List<KeyCode> { KeyCode.LeftArrow, KeyCode.A };
    public List<KeyCode> rotateRightKeys = new List<KeyCode> { KeyCode.RightArrow, KeyCode.D };


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Ship Start");
    }

    // Update is called once per frame
    void Update()
    {
        // Print initial position
        Debug.Log("Ship Position: " + transform.position);

        // Get movement using user input
        UpdateMovement();

        // Enforce the bounds on the velocity and rotation speed
        EnforceMovementBounds();

        // Update the position and rotation of the ship
        ApplyMovement();
    }

    // Enforce the bounds on the velocity and rotation speed
    void EnforceMovementBounds()
    {
        // Enforce bounds on the velocity
        if (velocity.magnitude > maxMovementSpeed)
        {
            velocity = velocity.normalized * maxMovementSpeed;
        }

        // Enforce bounds on the rotation speed
        if (rotationSpeed > maxRotationSpeed)
        {
            rotationSpeed = maxRotationSpeed;
        } else if (rotationSpeed < -maxRotationSpeed)
        {
            rotationSpeed = -maxRotationSpeed;
        }
    }

    // Update movement using user input
    // Acceleration is applied in the direction of the ship
    void UpdateMovement()
    {
        // Check if the user wants to accelerate
        if (InputIsPressed(accelerateKeys))
        {
            // Accelerate in the direction of the ship
            velocity += new Vector2 (
                Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad),
                Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad)
            ) * movementAcceleration * Time.deltaTime;
        }

        // Check if the user wants to decelerate
        if (InputIsPressed(decelerateKeys))
        {
            // Decelerate in the direction of the ship
            velocity -= new Vector2 (
                Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad),
                Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad)
            ) * movementAcceleration * Time.deltaTime;
        }

        // Check if the user wants to rotate left
        if (InputIsPressed(rotateLeftKeys))
        {
            // Rotate left
            rotationSpeed += rotationAcceleration * Time.deltaTime;
        }

        // Check if the user wants to rotate right
        if (InputIsPressed(rotateRightKeys))
        {
            // Rotate right
            rotationSpeed -= rotationAcceleration * Time.deltaTime;
        }

        // Rotation loops around 360 degrees
        if (transform.rotation.eulerAngles.z > 360)
        {
            transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z - 360);
        } else if (transform.rotation.eulerAngles.z < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 360);
        }
    }

    // Check if any of the keys in the list is pressed
    bool InputIsPressed(List<KeyCode> keys)
    {
        // Loop over all keys in the list
        foreach (KeyCode key in keys)
        {
            // Check if the key is pressed
            if (Input.GetKey(key))
            {
                // The key is pressed
                return true;
            }
        }

        // None of the keys in the list is pressed
        return false;
    }

    // Update the position and rotation of the ship
    void ApplyMovement()
    {
        // Update the position of the ship
        transform.position += new Vector3(velocity.x, velocity.y, 0) * Time.deltaTime;
        velocityMagnitude = velocity.magnitude;

        // Update the rotation of the ship
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + rotationSpeed * Time.deltaTime);
    }
}
