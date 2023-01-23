using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildShip : MonoBehaviour
{
    // Ship component prefab container
    public List<GameObject> shipComponentPrefabs = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // Generate the ship components
        for (int i = 0; i < shipComponentPrefabs.Count; i++)
        {
            // Generate a random position
            Vector3 position = new Vector3(0, i, 0);

            // Generate a random rotation
            Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));

            // Instantiate the ship component
            GameObject shipComponent = Instantiate(shipComponentPrefabs[i], position, rotation);

            // Add collider
            shipComponent.AddComponent<PolygonCollider2D>();

            // Set self as parent
            shipComponent.transform.parent = transform;
        }
    }
}
