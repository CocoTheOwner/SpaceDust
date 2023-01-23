using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space : MonoBehaviour
{
    public GameObject asteroidPrefab;
    private List<GameObject> asteroids = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // Generate a random number of asteroids
        int numAsteroids = Random.Range(10, 20);

        // Generate the asteroids
        for (int i = 0; i < numAsteroids; i++)
        {
            // Generate a random position
            Vector3 position = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);

            // Generate a random rotation
            Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));

            // Generate a random scale
            float scale = Random.Range(0.5f, 2f);

            // Instantiate the asteroid
            GameObject asteroid = Instantiate(asteroidPrefab, position, rotation);
            asteroid.transform.localScale = new Vector3(scale, scale, 1);

            // Add collider
            asteroid.AddComponent<PolygonCollider2D>();

            // Set self as parent
            asteroid.transform.parent = transform;

            // Add the asteroid to the list
            asteroids.Add(asteroid);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
