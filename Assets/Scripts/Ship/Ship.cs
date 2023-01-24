using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    // Ship component prefab container
    public List<GameObject> shipComponentPrefabs = new List<GameObject>();

    // Ship build hash table, mapping 2d coordinates to lists of ship components.
    // Origin is 0.5, 0.5 so the 0,0 tile is aligned with the rotation point
    // Orientation is positive y is up, positive x is right
    private Dictionary<Vector2, List<GameObject>> shipComponents = new Dictionary<Vector2, List<GameObject>>();

    // Start is called before the first frame update
    void Start()
    {
        // Generate a 
    }
}
