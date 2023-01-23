using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // camera will follow this object
    public Transform Target;
    // offset between camera and target
    public Vector3 Offset;
 
    private void LateUpdate()
    {
        // update position
        transform.position = Target.position + Offset;
    }
}