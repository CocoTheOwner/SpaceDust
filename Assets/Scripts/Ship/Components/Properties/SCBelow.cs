using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ShipComponentBelow : MonoBehaviour
{
    // The ship component layer. Lowest layer is 0.
    int layer { get; set; }

    // The ship component size
    Vector2 size { get; set; }

    // Required layer type to be present in all tiles below the component
    int requiredLayer { get; set; }
}