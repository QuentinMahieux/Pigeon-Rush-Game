using UnityEngine;

public class LookPlayer : MonoBehaviour
{
    
    void Update()
    {
        transform.LookAt(PlayerController.instance.transform);
    }
}
