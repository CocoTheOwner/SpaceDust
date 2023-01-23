using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentGridPlacement : MonoBehaviour
{

    // The grid spacing
    public int gridSpacing = 2;

    // Start is called before the first frame update
    void Start()
    {
        // Move all components to a grid pattern
        int x = 0;
        int y = 0;
        int numComponents = transform.childCount;
        int gridSize = Mathf.CeilToInt(Mathf.Sqrt(numComponents));
        foreach (Transform child in transform)
        {
            child.position = new Vector3(x * gridSpacing, y * gridSpacing, 0);
            x++;
            if (x >= gridSize)
            {
                x = 0;
                y++;
            }
        }
    }
}
