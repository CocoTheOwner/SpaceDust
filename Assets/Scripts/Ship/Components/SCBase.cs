using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public inte ShipComponentBase : MonoBehaviour
{
    // Whether the component is active
    public bool active;

    // The ship component layer. Lowest layer is 0.
    public int layer = 0;

    // The ship component size
    public Vector2 size;
}
