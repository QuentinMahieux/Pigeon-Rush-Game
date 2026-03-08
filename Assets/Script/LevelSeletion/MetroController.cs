using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MetroController : MonoBehaviour
{
    public static MetroController instance;
    public float speed = 2;
    public Rigidbody rb;
    
    [Header("Station Information")]
    public StationMetro actualStation;
    public Transform destination;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("There is more than one MetroController in the scene");
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StationMetro"))
        {
            destination = null;
            rb.linearVelocity = Vector3.zero;
            actualStation = other.gameObject.GetComponent<StationMetro>();
            
            CameraFollow.instance.gameObject.SetActive(true);
            CameraFollow.instance.StartFollow(actualStation.transform, actualStation.levelData);
        }
    }
    
    void Update()
    {
        if (!actualStation)
        {
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.D) && actualStation.D)
        {
            SetDestination(actualStation.D);
        }
        if (Input.GetKeyDown(KeyCode.A) && actualStation.Q)
        {
            SetDestination(actualStation.Q);
        }
        if (Input.GetKeyDown(KeyCode.W)&& actualStation.Z)
        {
            SetDestination(actualStation.Z);
        }
        if (Input.GetKeyDown(KeyCode.S) && actualStation.S)
        {
            SetDestination(actualStation.S);
        }
    }

    void FixedUpdate()
    {
        if (!destination)
        {
            return;
        }
        Vector3 direction = destination.position - transform.position;
        rb.linearVelocity = direction.normalized * speed;
        direction.y = 0;
        
        transform.rotation = Quaternion.LookRotation(direction) * Quaternion.Euler(0, -90, 0);
    }

    void SetDestination(StationMetro newDestination)
    {
        if (actualStation.isWin) {}
        else if (!newDestination.isWin)
        {
            return;
        }
        destination = newDestination.transform;
        CameraFollow.instance.StopFollow();

    }
    
    public void StartLevel()
    {
        SceneManager.LoadScene(actualStation.levelData.levelName);
    }
}
