using UnityEngine;

public class ComponentCameraControl : MonoBehaviour
{
    // Initial zoom level
    private float initialZoom = 5;

    // Percentage of current zoom to zoom in/out
    public float zoomPercent = 10;

    // Speed of movement in units per frame
    public float moveSpeed = 0.1f;

    void Start()
    {
        initialZoom = GetComponent<Camera>().orthographicSize;
    }

    void Update()
    {
        float zoomFactor = GetComponent<Camera>().orthographicSize / initialZoom;

        // Arrows and WASD to move
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, moveSpeed * zoomFactor, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -moveSpeed * zoomFactor, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-moveSpeed * zoomFactor, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(moveSpeed * zoomFactor, 0, 0);
        }

        // Scroll wheel to zoom on camera size
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            GetComponent<Camera>().orthographicSize *= 1 - zoomPercent/100;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            GetComponent<Camera>().orthographicSize *= 1 + zoomPercent/100;
        }

        // Space to reset to origin
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position = new Vector3(0, 0, -10);
            GetComponent<Camera>().orthographicSize = initialZoom;
        }
    }
}
