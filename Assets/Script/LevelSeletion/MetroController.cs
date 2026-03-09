using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MetroController : MonoBehaviour
{
    public static MetroController instance;
    public float speed = 2;
    public Rigidbody rb;

    [Header("Station Information")] public StationMetro actualStation;
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

    void Start()
    {
        ChargeCoordonee();
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

        if (Input.GetKeyDown(KeyCode.W) && actualStation.Z)
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
        if (actualStation.isWin)
        {
        }
        else if (!newDestination.isWin)
        {
            return;
        }

        destination = newDestination.transform;
        CameraFollow.instance.StopFollow();

    }

    void ChargeCoordonee()
    {
        if (!PlayerPrefs.HasKey("MetroCoordonee"))
        {
            PlayerPrefs.SetString("MetroCoordonee", "true");
            SetCoordonee();
        }
        else
        {
            transform.position = new Vector3(
                SaveLevel.instance.GetCoordonee("MetroPositionX"),
                SaveLevel.instance.GetCoordonee("MetroPositionY"),
                SaveLevel.instance.GetCoordonee("MetroPositionZ"));
            transform.rotation = new Quaternion(
                SaveLevel.instance.GetCoordonee("MetroRotationX"),
                SaveLevel.instance.GetCoordonee("MetroRotationY"),
                SaveLevel.instance.GetCoordonee("MetroRotationZ"),
                SaveLevel.instance.GetCoordonee("MetroRotationW")
            );
        }
    }

    public void SetCoordonee()
    {
        SaveLevel.instance.SetSaveCoordonne("MetroPositionX", transform.position.x);
        SaveLevel.instance.SetSaveCoordonne("MetroPositionY", transform.position.y);
        SaveLevel.instance.SetSaveCoordonne("MetroPositionZ", transform.position.z);

        SaveLevel.instance.SetSaveCoordonne("MetroRotationX", transform.rotation.x);
        SaveLevel.instance.SetSaveCoordonne("MetroRotationY", transform.rotation.y);
        SaveLevel.instance.SetSaveCoordonne("MetroRotationZ", transform.rotation.z);
        SaveLevel.instance.SetSaveCoordonne("MetroRotationW", transform.rotation.w);   
    }
    
}