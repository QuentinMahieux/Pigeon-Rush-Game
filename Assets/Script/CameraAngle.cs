using UnityEngine;

public class CameraAngle : MonoBehaviour
{
    
    void LateUpdate()
    {
        transform.rotation = PlayerController.instance.transform.rotation;
    }
}
