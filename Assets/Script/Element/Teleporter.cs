using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public List<string> tags;
    public Transform exit;

    void OnTriggerEnter(Collider other)
    {
        if (tags.Contains(other.tag))
        {
            other.transform.position = exit.position;
        }
    }
}
